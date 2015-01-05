using System;

public abstract class Quest<QuestSC, DefinitionSC> : Quest
	where QuestSC : Quest<QuestSC, DefinitionSC>
	where DefinitionSC : QuestDefinition {

	public Quest(DefinitionSC definition) : base(definition) {}

	// definition

	new public DefinitionSC definition { get { return _definition as DefinitionSC; } }

	// events

	new static public event QuestEvent<QuestSC>.Subscriber onAnyQuestStart;
	new static public event QuestEvent<QuestSC>.Subscriber onAnyQuestComplete;

	new public event QuestEvent<QuestSC>.Subscriber onQuestStart;
	new public event QuestEvent<QuestSC>.Subscriber onQuestComplete;

	override protected void _PostStart() {
		base._PostStart();
		if (Quest<QuestSC, DefinitionSC>.onAnyQuestStart != null) Quest<QuestSC, DefinitionSC>.onAnyQuestStart(this as QuestSC);
		if (this.onQuestStart != null) this.onQuestStart(this as QuestSC);
	}

	override protected void _PostComplete() {
		base._PostComplete();
		if (Quest<QuestSC, DefinitionSC>.onAnyQuestComplete != null) Quest<QuestSC, DefinitionSC>.onAnyQuestComplete(this as QuestSC);
		if (this.onQuestComplete != null) this.onQuestComplete(this as QuestSC);
	}

}
