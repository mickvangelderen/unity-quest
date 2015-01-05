using System;
using System.Collections.Generic;
using UnityEngine;

public class ParallelQuest : RecursiveQuest<ParallelQuest, ParallelQuestDefinition> {

	public ParallelQuest(ParallelQuestDefinition definition) : base(definition) {}

	override protected void _Start() {
		base._Start();
		foreach (Quest q in children) {
			q.Start();
		}
	}

}
