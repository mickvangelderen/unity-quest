using System;

public abstract class Quest<QuestSC, DefinitionSC> : Quest
	where QuestSC : Quest<QuestSC, DefinitionSC>
	where DefinitionSC : QuestDefinition {

	public Quest(DefinitionSC definition) : base(definition) {}

	// definition

	new public DefinitionSC definition { get { return _definition as DefinitionSC; } }

	// events

	new static public event QuestEvent<QuestSC>.Subscriber onAnyQuestStart;
	new static public event QuestEvent<QuestSC>.Subscriber onAnyQuestCancel;
	new static public event QuestEvent<QuestSC>.Subscriber onAnyQuestComplete;

	new public event QuestEvent<QuestSC>.Subscriber onQuestStart;
	new public event QuestEvent<QuestSC>.Subscriber onQuestCancel;
	new public event QuestEvent<QuestSC>.Subscriber onQuestComplete;

	override public void Start() {
		base.Start();
		if (Quest<QuestSC, DefinitionSC>.onAnyQuestStart != null) Quest<QuestSC, DefinitionSC>.onAnyQuestStart(this as QuestSC);
		if (this.onQuestStart != null) this.onQuestStart(this as QuestSC);
	}

	override public void Cancel() {
		base.Cancel();
		if (Quest<QuestSC, DefinitionSC>.onAnyQuestCancel != null) Quest<QuestSC, DefinitionSC>.onAnyQuestCancel(this as QuestSC);
		if (this.onQuestCancel != null) this.onQuestCancel(this as QuestSC);
	}

	override public void Complete() {
		base.Complete();
		if (Quest<QuestSC, DefinitionSC>.onAnyQuestComplete != null) Quest<QuestSC, DefinitionSC>.onAnyQuestComplete(this as QuestSC);
		if (this.onQuestComplete != null) this.onQuestComplete(this as QuestSC);
	}

}
