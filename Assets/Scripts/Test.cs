using System;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// any quest
		Quest.onQuestStart += OnQuestEvent;

		QuestDefinition d = gameObject.GetComponent<CollectQuestDefinition>();

		Quest a = d.Create();
		Quest b = d.Create();

		((CollectQuest)a).onQuestStart += OnCollectQuestEvent;
		((CollectQuest)b).onQuestStart += OnCollectQuestEvent;

		a.Start();
		b.Start();
	}

	private static void OnQuestEvent(Quest quest) {
		Debug.Log(quest.definition.title + " state " + quest.state);
		// Quest.onQuestStart -= OnQuestEvent;
	}

	private static void OnCollectQuestEvent(CollectQuest quest) {
		Debug.Log(quest.definition.title + " state " + quest.state + " count "+ quest.count + "/" + quest.definition.count);
	}

	// Update is called once per frame
	void Update () {

	}
}
