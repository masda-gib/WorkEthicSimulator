using UnityEngine;
using System.Collections;

public class LevelItem : ScriptableObject 
{
	public string itemCode;
	public string itemName;
	public Sprite baseSprite;

	public ItemConsequence kickConsequence;
	public ItemConsequence eatConsequence;
	public ItemConsequence catchConsequence;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
