using UnityEngine;
using System.Collections;

public class LevelSequence : ScriptableObject 
{
	[System.Serializable]
	public struct ItemSpawnData
	{
		public float beat;
		public string itemType;
	}

	public float tempoBPM = 90;
	public ItemSpawnData[] items;
}
