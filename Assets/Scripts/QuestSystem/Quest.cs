using System;

public class Quest {

	// static

	public enum State { CREATED, STARTED, COMPLETED };

	static public event QuestEvent<Quest>.Subscriber onAnyQuestStart;
	static public event QuestEvent<Quest>.Subscriber onAnyQuestComplete;

	// instance

	public State state = State.CREATED;
	protected QuestDefinition _definition;
	public QuestDefinition definition { get { return _definition; } }

	public event QuestEvent<Quest>.Subscriber onQuestStart;
	public event QuestEvent<Quest>.Subscriber onQuestComplete;

	// methods
	
	public Quest(QuestDefinition definition) {
		this._definition = definition;
	}

	public void Start() {
		if (_PreStart() == false) return;
		_Start();
		_PostStart();
	}

	virtual protected bool _PreStart() {
		return state != State.STARTED;
	}

	virtual protected void _Start() {
		state = State.STARTED;
	}

	virtual protected void _PostStart() {
		if (Quest.onAnyQuestStart != null) Quest.onAnyQuestStart(this);
		if (this.onQuestStart != null) this.onQuestStart(this);
	}

	public void Complete() {
		if (_PreComplete() == false) return;
		_Complete();
		_PostComplete();
	}

	virtual protected bool _PreComplete() {
		return state != State.COMPLETED;
	}

	virtual protected void _Complete() {
		state = State.COMPLETED;
	}

	virtual protected void _PostComplete() {
		if (Quest.onAnyQuestComplete != null) Quest.onAnyQuestComplete(this);
		if (this.onQuestComplete != null) this.onQuestComplete(this);
	}

}
