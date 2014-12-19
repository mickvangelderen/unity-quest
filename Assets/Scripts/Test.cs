using System;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

		CollectQuest a = new CollectQuest { title = "a" };
		CollectQuest b = new CollectQuest { title = "b" };

		a.onQuestStart += OnQuestEvent;
		a.onQuestStop += OnQuestEvent;
		b.onQuestStart += OnQuestEvent;
		b.onQuestStop += OnQuestEvent;

		a.Start();
		a.Cancel();

		b.Start();
		b.Cancel();
	}

	private static void OnQuestEvent(CollectQuest quest) {
		Debug.Log(quest.title + " state " + quest.state + " count "+ quest.count);
	}

	// Update is called once per frame
	void Update () {

	}
}
