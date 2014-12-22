using System;

public class SerialQuestDefinition : QuestDefinition {

	override public Quest Create() {
		return new SerialQuest(this);
	}
	
}
