using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class ActionTrigger : MonoBehaviour
{
	public WES_LevelSetup levelSetup;

	private List<Collider2D> currentColliders;

	void Awake()
	{
		currentColliders = new List<Collider2D> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		currentColliders.Add (other);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		currentColliders.Remove (other);
	}

	void Update()
	{
		var col = GetLowestCollider ();
		if (col == null) 
		{
			return;
		}

		if (levelSetup != null) 
		{
			LevelItem item;
			if (levelSetup.spawnedItems.TryGetValue(col, out item))
			{
				bool actionDone = false;
				if (CrossPlatformInputManager.GetButtonDown ("Kick")) 
				{
					actionDone = true;
					levelSetup.ItemKicked(item.kickConsequence);
				}
				if (CrossPlatformInputManager.GetButtonDown ("Eat")) 
				{
					actionDone = true;
					levelSetup.ItemEaten(item.eatConsequence);
				}
				
				if(actionDone)
				{
					levelSetup.spawnedItems.Remove(col);
					currentColliders.Remove (col);
					GameObject.Destroy(col.gameObject);
				}
			}
		}
	}

	private Collider2D GetLowestCollider()
	{
		float lowestY = 10000;
		Collider2D lowest = null;
		foreach (var col in currentColliders) 
		{
			if(col.transform.position.y < lowestY)
			{
				lowest = col;
				lowestY = col.transform.position.y;
			}
		}
		return lowest;
	}
}