using System;
using System.Collections.Generic;
using UnityEngine;

public class ParallelQuest : Quest<ParallelQuest, ParallelQuestDefinition> {

	public List<Quest> children = new List<Quest>();

	public ParallelQuest(ParallelQuestDefinition definition) : base(definition) {}

	override public void Start() {
		foreach (Transform t in definition.transform) {
			foreach (QuestDefinition d in t.GetComponents<QuestDefinition>()) {
				Quest q = d.Create();
				q.onQuestComplete += OnChildQuestComplete;
				children.Add(q);
				q.Start();
			}
		}

		base.Start();
	}

	private void OnChildQuestComplete(Quest _) {
		foreach (Quest q in children) {
			if (q.state != Quest.State.COMPLETED) return;
		}
		Complete();
	}

}
