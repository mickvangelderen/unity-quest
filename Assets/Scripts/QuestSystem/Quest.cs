using System;

public class Quest {

	// static

	public enum State { CREATED, STARTED, CANCELLED, COMPLETED };

	static public event QuestEvent<Quest>.Subscriber onAnyQuestStart;
	static public event QuestEvent<Quest>.Subscriber onAnyQuestCancel;
	static public event QuestEvent<Quest>.Subscriber onAnyQuestComplete;

	// instance

	public State state = State.CREATED;
	protected QuestDefinition _definition;
	public QuestDefinition definition { get { return _definition; } }

	public event QuestEvent<Quest>.Subscriber onQuestStart;
	public event QuestEvent<Quest>.Subscriber onQuestCancel;
	public event QuestEvent<Quest>.Subscriber onQuestComplete;

	// methods
	
	public Quest(QuestDefinition definition) {
		this._definition = definition;
	}

	virtual public void Start() {
		if (state == State.STARTED) return;
		state = State.STARTED;
		if (Quest.onAnyQuestStart != null) Quest.onAnyQuestStart(this);
		if (this.onQuestStart != null) this.onQuestStart(this);
	}

	virtual public void Cancel() {
		if (state == State.CANCELLED) return;
		state = State.CANCELLED;
		if (Quest.onAnyQuestCancel != null) Quest.onAnyQuestCancel(this);
		if (this.onQuestCancel != null) this.onQuestCancel(this);
	}

	virtual public void Complete() {
		if (state == State.COMPLETED) return;
		state = State.COMPLETED;
		if (Quest.onAnyQuestComplete != null) Quest.onAnyQuestComplete(this);
		if (this.onQuestComplete != null) this.onQuestComplete(this);
	}

}
