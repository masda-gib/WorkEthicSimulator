using UnityEngine;
using System.Collections;

public class CatchTrigger : MonoBehaviour 
{
	public WES_LevelSetup levelSetup;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (levelSetup != null) 
		{
			LevelItem item;
			if (levelSetup.spawnedItems.TryGetValue(other, out item))
			{
				levelSetup.ItemCaught(item.catchConsequence);

				levelSetup.spawnedItems.Remove(other);
				GameObject.Destroy(other.gameObject);
			}
		}
	}
}
