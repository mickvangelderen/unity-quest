using System;
using UnityEngine;

public class Item : MonoBehaviour {

	public static event ItemEvent.Collect onAnyItemCollect;

	public void OnTriggerEnter(Collider collider) {
		if (Item.onAnyItemCollect != null) Item.onAnyItemCollect(gameObject, collider.gameObject);
		GameObject.Destroy(gameObject);
	}

}
