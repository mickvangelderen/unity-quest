using System;

public class CollectQuestDefinition : QuestDefinition {

	public int count = 1;
	public string objectName;
	
	override public Quest Create() {
		return new CollectQuest(this);
	}
	
}
