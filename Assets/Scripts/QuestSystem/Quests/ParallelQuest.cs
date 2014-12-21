using System;

public class ParallelQuest : Quest<ParallelQuest, QuestDefinition> {

	// public List<Quest> children;

	public ParallelQuest(CollectQuestDefinition definition) : base(definition) {}

	new public void Start() {
		// foreach (Transform t in definition.transform) {
		// 	foreach (QuestDefinition d in t.GetComponents<QuestDefinition>()) {
		// 		children.Add()
		// 	}
		// }

		base.Start();
	}
}
