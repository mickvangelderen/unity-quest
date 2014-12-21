using System;

public abstract class Quest<QuestSC, DefinitionSC> : Quest
	where QuestSC : Quest<QuestSC, DefinitionSC>
	where DefinitionSC : QuestDefinition {

	public Quest(DefinitionSC definition) : base(definition) {}

	// definition

	new public DefinitionSC definition { get { return _definition as DefinitionSC; } }

	// events

	new public event QuestEvent<QuestSC>.Subscriber onQuestStart;
	new public event QuestEvent<QuestSC>.Subscriber onQuestCancel;
	new public event QuestEvent<QuestSC>.Subscriber onQuestComplete;

	new public void Start() {
		base.Start();
		if (onQuestStart != null) onQuestStart(this as QuestSC);
	}

	new public void Cancel() {
		base.Cancel();
		if (onQuestCancel != null) onQuestCancel(this as QuestSC);
	}

	new public void Complete() {
		base.Complete();
		if (onQuestComplete != null) onQuestComplete(this as QuestSC);
	}

}
