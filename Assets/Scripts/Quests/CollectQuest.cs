using System;
using UnityEngine;

public class CollectQuest : QuestWithEvents<CollectQuest> {

	new public CollectQuestDefinition definition {
		get { return _definition as CollectQuestDefinition; }
	}

	public int count = 0;

	public CollectQuest(CollectQuestDefinition definition) : base(definition) {}
}
