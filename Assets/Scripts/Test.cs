using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	private class QuestStartEventCondition : QuestStartEvent.Condition {
		public bool allow;

		public bool On(QuestStartEvent e) {
			Debug.Log((allow ? "Allowing" : "Denying") + " Quest " + e.quest.title);
			return allow;
		}
	}

	private class QuestStartEventAction : QuestStartEvent.Action {
		public void On(QuestStartEvent e) {
			Debug.Log("Quest " + e.quest.title + (e.quest.started ? " started" : " not started"));
		}
	}

	// Use this for initialization
	void Start () {

		QuestStartEventCondition allow = new QuestStartEventCondition { allow = true };
		QuestStartEventCondition deny = new QuestStartEventCondition { allow = false };
		QuestStartEventAction print = new QuestStartEventAction();

		Quest a = new Quest { title = "a" };
		Quest b = new Quest { title = "b" };

		a.Register(allow).Register(allow).Register(print);

		b.Register(allow).Register(deny).Register(print);

		a.Start();
		b.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
