using UnityEngine;
using System.Collections;

public static class EditorMenus 
{
	[UnityEditor.MenuItem("WES/Create ScriptableObject/LevelItem")]
	public static void CreateLevelItem()
	{
		ScriptableObjectUtility.CreateAsset<LevelItem> ();
	}

	[UnityEditor.MenuItem("WES/Create ScriptableObject/LevelSequence")]
	public static void CreateLevelSequence()
	{
		ScriptableObjectUtility.CreateAsset<LevelSequence> ();
	}
}
