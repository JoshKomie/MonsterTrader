using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;


public class Tiles : MonoBehaviour 
{
	#region sprites
	public Sprite Forest;
	public Sprite Mountains;
	public Sprite Store;
	#endregion
	
	private const ushort tilesize = 1;
	
	public const ushort EMPTY = 0;
	public const ushort FOREST = 1;
	public const ushort MOUNTAINS = 2;
	public const ushort STORE = 3;
	
	public const float FOREST_CHANCE = .5f;
	public const float MOUNTAIN_CHANCE = .3f;
	
	
	private Dictionary<Pair, Store> stores;
	private ushort[,] tileMap;
	
	public void Start()
	{
		tileMap = new ushort[10, 10] { 
												{1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }, 
												{1, 1, 0, 1, 1, 1, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
												{0, 3, 0, 0, 0, 0, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 2, 0, 0, 0, 0, 0 }, 
												{0, 0, 2, 2, 0, 0, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 0, 0, 0, 3, 0, 0 }, 			
												{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }				
												
										  };
										  
										
		BuildTilemap(tileMap);	
	}
	
	
	public void BuildTilemap(ushort[,] tilemap)
	{
		for (int y = 0; y < tilemap.GetLength(1); y++)
		{
			for (int x = 0;x < tilemap.GetLength(0); x++)
			{
				
				
				GameObject tile = new GameObject();
				SpriteRenderer s = tile.AddComponent<SpriteRenderer>();
				switch (tilemap[y, x])
				{
					
					case EMPTY:
						break;
					case FOREST:
						s.sprite = Forest;
						break;
					case MOUNTAINS:
						s.sprite = Mountains;
						break;
					case STORE:
						s.sprite = Store;
						if (stores == null)
							stores = new Dictionary<Pair, Store>();
						Debug.Log (x + " " + y);
						stores.Add(new Pair(x, y), new Store());
						break;
      
				}
				
				tile.transform.position = new Vector2(x * tilesize, y * tilesize);
			}
		}
	}
	
	public Store StoreAt(Pair loc)
	{
		Debug.Log ("store request, " + loc);
		return stores[loc];
	}
	public ushort TileAt(Pair location)
	{
		//should bounds check here
		try
		{
			return tileMap[location.Y, location.X];
		}
		catch (IndexOutOfRangeException e)
		{
			return 9999;
		}
		
	}
}
