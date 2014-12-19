using System;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		CollectQuestDefinition d = new CollectQuestDefinition();

		CollectQuest a = new CollectQuest(d);
		CollectQuest b = new CollectQuest(d);

		a.onQuestStart += OnQuestEvent;
		b.onQuestStart += OnQuestEvent;

		a.Start();
		a.Cancel();

		b.Start();
		b.Cancel();
	}

	private static void OnQuestEvent(CollectQuest quest) {
		Debug.Log(quest.definition.title + " state " + quest.state + " count "+ quest.count + "/" + quest.definition.count);
	}

	// Update is called once per frame
	void Update () {

	}
}
