using System.Collections.Generic;
using System;
using UnityEngine;

public class Quest {

	public string title;
	public bool started = false;
	
	private List<QuestStartEvent.Condition> conditions = new List<QuestStartEvent.Condition>();
	public Quest Register(QuestStartEvent.Condition handler) { conditions.Add(handler); return this; }
	public Quest Unregister(QuestStartEvent.Condition handler) { conditions.Remove(handler); return this; }

	private List<QuestStartEvent.Action> actions = new List<QuestStartEvent.Action>();
	public Quest Register(QuestStartEvent.Action handler) { actions.Add(handler); return this; }	
	public Quest Unregister(QuestStartEvent.Action handler) { actions.Remove(handler); return this; }

	public void Start() {
		// Create event
		QuestStartEvent e = new QuestStartEvent { quest = this };

		// Check conditions
		foreach (QuestStartEvent.Condition c in conditions) {
			if (c.On(e) == false) {
				return;
			}
		}

		// Make changes
		started = true;

		// Perform actions
		foreach (QuestStartEvent.Action a in actions) {
			a.On(e);
		}
	}

}
