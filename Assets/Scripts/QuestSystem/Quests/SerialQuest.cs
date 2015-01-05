using System;
using System.Collections.Generic;
using UnityEngine;

public class SerialQuest : RecursiveQuest<SerialQuest, SerialQuestDefinition> {

	public SerialQuest(SerialQuestDefinition definition) : base(definition) {}

	override protected void Check() {
		// Check if all quests have been completed
		base.Check();
		// Check if there is quest ready to be started
		foreach (Quest q in children) {
			if (q.state != Quest.State.CREATED) continue;
			q.Start();
			return;
		}
	}

}
