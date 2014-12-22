using System;
using System.Collections.Generic;
using UnityEngine;

public class SerialQuest : Quest<SerialQuest, SerialQuestDefinition> {

	public List<Quest> children = new List<Quest>();

	public SerialQuest(SerialQuestDefinition definition) : base(definition) {}

	override public void Start() {
		foreach (Transform t in definition.transform) {
			foreach (QuestDefinition d in t.GetComponents<QuestDefinition>()) {
				Quest q = d.Create();
				q.onQuestComplete += OnChildQuestComplete;
				children.Add(q);
			}
		}
		base.Start();
		Next();
	}

	private void Next() {
		// Start next quest if one is available
		foreach (Quest q in children) {
			if (q.state != Quest.State.CREATED) continue;
			q.Start();
			return;
		}
		// Otherwise check if all sub quests have been completed
		foreach (Quest q in children) {
			if (q.state != Quest.State.COMPLETED) return;
		}
		Complete();
	}

	private void OnChildQuestComplete(Quest _) {
		Next();
	}

}
