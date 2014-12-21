using System;
using UnityEngine;

public class CollectQuest : Quest<CollectQuest, CollectQuestDefinition> {

	public int count = 0;

	public CollectQuest(CollectQuestDefinition definition) : base(definition) {}

	override public void Start() {

		Item.onAnyItemCollect += OnAnyItemCollect;

		base.Start();
	}

	override public void Complete() {

		Item.onAnyItemCollect -= OnAnyItemCollect;

		base.Complete();
	}

	private void OnAnyItemCollect(GameObject item, GameObject unit) {
		if (item.name != definition.objectName) return;

		if (++count >= definition.count) Complete();

	}


}
