using System.Collections.Generic;
using System;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public List<GameObject> startingQuests = new List<GameObject>();

	public List<Quest> quests = new List<Quest>();

	void Start () {
		// Register handlers on all quests for logging purposes
		Quest.onAnyQuestStart += OnQuestEvent;
		Quest.onAnyQuestComplete += OnQuestEvent;

		// Start all starting quests
		foreach (GameObject o in startingQuests) {
			foreach (QuestDefinition d in o.GetComponents<QuestDefinition>()) {
				Quest q = d.Create();
				quests.Add(q);
				q.Start();
			}
		}
	}

	private static void OnQuestEvent(Quest quest) {
		Debug.Log(quest.state + ": " + quest.definition.title);
	}

}
