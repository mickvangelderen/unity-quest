using System;
using UnityEngine;

public abstract class QuestDefinition : MonoBehaviour {

	public string title;

	abstract public Quest Create();
}
