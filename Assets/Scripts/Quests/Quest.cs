using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Quest {

	public enum State { CREATED, STARTED, CANCELLED, COMPLETED };

	public State state = State.CREATED;
	public string title;

}

public abstract class Quest<QuestType> : Quest where QuestType : Quest<QuestType> {

	public event QuestEvent<QuestType>.Subscriber onQuestStart;
	public event QuestEvent<QuestType>.Subscriber onQuestStop;

	public void Start() {
		if (state == State.STARTED) return;
		state = State.STARTED;
		if (onQuestStart != null) onQuestStart(this as QuestType);
	}

	public void Cancel() {
		if (state == State.CANCELLED) return;
		state = State.CANCELLED;
		if (onQuestStop != null) onQuestStop(this as QuestType);
	}

	public void Complete() {
		if (state == State.COMPLETED) return;
		state = State.COMPLETED;
		if (onQuestStop != null) onQuestStop(this as QuestType);
	}

}
