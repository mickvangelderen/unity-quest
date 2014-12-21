using System;

public class CollectQuest : Quest<CollectQuest, CollectQuestDefinition> {

	public int count = 0;

	public CollectQuest(CollectQuestDefinition definition) : base(definition) {}
}
