using System;

public class ParallelQuestDefinition : QuestDefinition {

	override public Quest Create() {
		return new ParallelQuest(this);
	}
	
}
