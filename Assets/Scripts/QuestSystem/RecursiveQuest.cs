using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class RecursiveQuest<QuestSC, DefinitionSC> : Quest<QuestSC, DefinitionSC>
	where QuestSC : Quest<QuestSC, DefinitionSC>
	where DefinitionSC : QuestDefinition {

	protected List<Quest> children = new List<Quest>();

	public RecursiveQuest(DefinitionSC definition) : base(definition) {}

	override protected void _Start() {
		base._Start();
		foreach (Transform t in definition.transform) {
			foreach (QuestDefinition d in t.GetComponents<QuestDefinition>()) {
				Quest q = d.Create();
				q.onQuestComplete += OnChildQuestComplete;
				children.Add(q);
			}
		}		
	}

	override protected void _PostStart() {
		base._PostStart();
		Check();
	}

	virtual protected void Check() {
		foreach (Quest q in children) {
			if (q.state != Quest.State.COMPLETED) return;
		}
		Complete();
	}
	
	private void OnChildQuestComplete(Quest quest) {
		quest.onQuestComplete -= OnChildQuestComplete;
		Check();
	}

}
