using System;

public abstract class QuestWithEvents<SubClass> : Quest where SubClass : QuestWithEvents<SubClass> {

	public event QuestEvent<SubClass>.Subscriber onQuestStart;
	public event QuestEvent<SubClass>.Subscriber onQuestCancel;
	public event QuestEvent<SubClass>.Subscriber onQuestComplete;

	public QuestWithEvents(QuestDefinition definition) : base(definition) {}

	new public void Start() {
		base.Start();
		if (onQuestStart != null) onQuestStart(this as SubClass);
	}

	new public void Cancel() {
		base.Cancel();
		if (onQuestCancel != null) onQuestCancel(this as SubClass);
	}

	new public void Complete() {
		base.Complete();
		if (onQuestComplete != null) onQuestComplete(this as SubClass);
	}

}
