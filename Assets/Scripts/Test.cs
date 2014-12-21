using System;
using UnityEngine;

public class Test : MonoBehaviour {

	public GameObject mainQuest;

	// Use this for initialization
	void Start () {

		// any quest
		Quest.onAnyQuestStart += OnQuestEvent;
		Quest.onAnyQuestComplete += OnQuestEvent;

		QuestDefinition d = mainQuest.GetComponent<QuestDefinition>();

		d.Create().Start();
	}

	private static void OnQuestEvent(Quest quest) {
		Debug.Log(quest.definition.title + " state " + quest.state);
	}

	// Update is called once per frame
	void Update () {

	}
}
