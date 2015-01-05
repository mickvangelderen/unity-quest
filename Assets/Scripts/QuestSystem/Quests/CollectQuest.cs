using System;
using UnityEngine;

public class CollectQuest : Quest<CollectQuest, CollectQuestDefinition> {

	public int count = 0;

	public CollectQuest(CollectQuestDefinition definition) : base(definition) {}

	override protected void _Start() {
		base._Start();
		Item.onAnyItemCollect += OnAnyItemCollect;
	}

	override protected void _Complete() {
		base._Complete();
		Item.onAnyItemCollect -= OnAnyItemCollect;
	}

	private void OnAnyItemCollect(GameObject item, GameObject unit) {
		if (item.name != definition.objectName) return;
		if (++count >= definition.count) Complete();
	}


}
