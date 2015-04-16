using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WES_LevelSetup : MonoBehaviour 
{
	public int points;
	public int energy;

	public Dictionary<Collider2D, LevelItem> spawnedItems;

	void Awake()
	{
		spawnedItems = new Dictionary<Collider2D, LevelItem> ();
		energy = 50;
	}
	
	// Use this for initialization
	void Start () {
		
	}

	public void ItemKicked (ItemConsequence cons)
	{
		UpdateStats (cons);
		Debug.Log ("Kicked! Points: " + cons.points + ", Energy: " + cons.energy);
	}

	public void ItemEaten (ItemConsequence cons)
	{
		UpdateStats (cons);
		Debug.Log ("Eaten! Points: " + cons.points + ", Energy: " + cons.energy);
	}

	public void ItemCaught (ItemConsequence cons)
	{
		UpdateStats (cons);
		Debug.Log ("Caught! Points: " + cons.points + ", Energy: " + cons.energy);
	}

	private void UpdateStats(ItemConsequence cons)
	{
		points += cons.points;
		energy += cons.energy;
	}
}
