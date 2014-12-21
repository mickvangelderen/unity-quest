using System;

public class Quest {

	public enum State { CREATED, STARTED, CANCELLED, COMPLETED };

	public static event QuestEvent<Quest>.Subscriber onQuestStart;
	public static event QuestEvent<Quest>.Subscriber onQuestCancel;
	public static event QuestEvent<Quest>.Subscriber onQuestComplete;

	public State state = State.CREATED;
	protected QuestDefinition _definition;
	public QuestDefinition definition { get { return _definition; } }

	public Quest(QuestDefinition definition) {
		this._definition = definition;
	}

	public void Start() {
		if (state == State.STARTED) return;
		state = State.STARTED;
		if (Quest.onQuestStart != null) Quest.onQuestStart(this);
	}

	public void Cancel() {
		if (state == State.CANCELLED) return;
		state = State.CANCELLED;
		if (Quest.onQuestCancel != null) Quest.onQuestCancel(this);
	}

	public void Complete() {
		if (state == State.COMPLETED) return;
		state = State.COMPLETED;
		if (Quest.onQuestComplete != null) Quest.onQuestComplete(this);
	}

}
