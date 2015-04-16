using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour 
{
	public WES_LevelSetup levelSetup;
	public LevelSequence sequence;
	public LevelItem[] itemLibrary;

	private int lastSpawnedIndex;
	private float beatDur;
	private float spawnTime;

	// Use this for initialization
	void Start () 
	{
		lastSpawnedIndex = -1;
		beatDur = (sequence.tempoBPM > 0) ? 60f / sequence.tempoBPM : 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnTime += Time.deltaTime;
		for (
			int i = lastSpawnedIndex + 1; 
			i < sequence.items.Length && spawnTime >= sequence.items[i].beat * beatDur;
			i++) 
		{
			lastSpawnedIndex = i;
			var item = FindItemForCode(sequence.items[i].itemType);
			if (item != null)
			{
				var go = Resources.Load<GameObject>("EmptyItem");
				var goInst = GameObject.Instantiate<GameObject>(go);
				goInst.transform.position = transform.position;
				var r = goInst.GetComponent<SpriteRenderer>();
				r.sprite = item.baseSprite;
				levelSetup.spawnedItems.Add(goInst.GetComponent<Collider2D>(), item);

				goInst.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -2), ForceMode2D.Impulse);
			}
		}
	}

	private LevelItem FindItemForCode(string code)
	{
		foreach (var item in itemLibrary) 
		{
			if(item.itemCode.StartsWith(code))
			{
				return item;
			}
		}
		return null;
	}
}
