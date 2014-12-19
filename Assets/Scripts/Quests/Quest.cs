using System;

public class Quest {

	public enum State { CREATED, STARTED, CANCELLED, COMPLETED };

	public State state = State.CREATED;
	protected QuestDefinition _definition;
	public QuestDefinition definition { get { return _definition; } }

	public Quest(QuestDefinition definition) {
		this._definition = definition;
	}

	public void Start() {
		if (state == State.STARTED) return;
		state = State.STARTED;
	}

	public void Cancel() {
		if (state == State.CANCELLED) return;
		state = State.CANCELLED;
	}

	public void Complete() {
		if (state == State.COMPLETED) return;
		state = State.COMPLETED;
	}

}
