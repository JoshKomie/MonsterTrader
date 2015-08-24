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
	public Sprite Lake;
	public Sprite Swamp;
	public Sprite Castle;
	public Sprite Cave;
	public Sprite HauntedHouse;
	
	
	#endregion
	
	private const ushort tilesize = 1;
	
	public const ushort EMPTY = 0;
	public const ushort FOREST = 1;
	public const ushort PLAYER = 2;
	public const ushort MOUNTAINS = 3;
	public const ushort SWAMP = 4;
	public const ushort LAKE = 5;
	public const ushort CAVE = 6;
	public const ushort CASTLE = 11;
	public const ushort HAUNTED_HOUSE = 12;
	public const ushort STORE = 20;
	
	public const float FOREST_CHANCE = .5f;
	public const float MOUNTAIN_CHANCE = .3f;
	public const float LAKE_CHANCE = .3f;
	public const float CAVE_CHANCE = .6f;
	public const float SWAMP_CHANCE = .3f;
	
	
			
	public const float EMPTY_DELAY = .3f;
	public const float FOREST_DELAY = .8f;
	public const float MOUNTAIN_DELAY = 1.5f;
	
	
	private Dictionary<Pair, Store> stores;
	private ushort[,] t1, t2, t3, t4, t5;
	private ushort[,] current;
	public void Start()
	{
		t1 = new ushort[10, 10] { 
												{1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }, 
												{1, 1, 0, 1, 1, 1, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
												{0, 3, 0, 0, 0, 0, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }, 
												{0, 0, 1, 1, 2, 0, 0, 0, 0, 0 }, 
												{0, 0, 2, 2, 0, 0, 0, 0, 0, 0 }, 
												{0, 0, 1, 1, 0, 0, 0, 0, 0, 0 }, 
												{0, 0, 0, 0, 0, 0, 0, 3, 0, 0 }, 			
												{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }				
												
										  };
										  
		t2 = new ushort[10, 10] { 
			{1, 1, 1, 1, 1, 0, 0, 0, 0, 0 }, 
			{1, 1, 0, 1, 1, 1, 0, 0, 0, 0 }, 
			{0, 0, 3, 3, 3, 0, 0, 0, 0, 0 }, 
			{0, 3, 0, 0, 0, 0, 0, 0, 0, 0 }, 
			{0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }, 
			{0, 0, 1, 1, 2, 0, 0, 0, 0, 0 }, 
			{0, 0, 2, 2, 0, 0, 0, 0, 0, 0 }, 
			{0, 0, 1, 1, 0, 0, 0, 0, 0, 0 }, 
			{0, 0, 0, 0, 0, 0, 0, 3, 0, 0 }, 			
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }				
			
		};								
										 
		t1 = CSVParse.Parse(CSVmaps.CSV1, 20, 20);								  
		t2 = CSVParse.Parse(CSVmaps.CSV2, 20, 20);	
		t3 = CSVParse.Parse(CSVmaps.CSV3, 20, 20);		
		t4 = CSVParse.Parse(CSVmaps.CSV4, 20, 20);		
		t5 = CSVParse.Parse(CSVmaps.CSV5, 20, 20);								
		BuildLevel(Global.Level);
	}
	
	public void BuildLevel(int level)
	{
		Debug.Log ("building tilemap");
		switch (level)
		{
			case 0:
				BuildTilemap(t1);
				current = t1;
				break;
		case 1:
			BuildTilemap(t2);
			current = t2;
			break;
		case 2:
			BuildTilemap(t3);
			current = t3;
			break;
		case 3:
			BuildTilemap(t4);
			current = t4;
			break;
		case 4:
			BuildTilemap(t5);
			current = t5;
			break;
			
		}
	}
	private void BuildTilemap(ushort[,] tilemap)
	{
		for (int y = 0; y < tilemap.GetLength(1); y++)
		{
			for (int x = 0;x < tilemap.GetLength(0); x++)
			{
				
				
				GameObject tile = new GameObject();
				SpriteRenderer s = tile.AddComponent<SpriteRenderer>();
				//Debug.Log ("tile" + tilemap[y, x]);
				switch (tilemap[y, x])
				{
		
					case EMPTY:
						break;
					case PLAYER:
						Global.SetPlayerLoc(x, y);
						break;
					case FOREST:
						s.sprite = Forest;
						break;
					case MOUNTAINS:
						s.sprite = Mountains;
						break;
					case LAKE:
						s.sprite = Lake;
						break;
					case SWAMP:
						s.sprite = Swamp;
						break;
					case CAVE:
						s.sprite = Cave;
						break;
					case CASTLE:
						s.sprite = Castle;
						if (stores == null)
							stores = new Dictionary<Pair, Store>();
						Debug.Log (x + " " + y);
						stores.Add(new Pair(x, y), new Store(true));
	    				  break;
					case HAUNTED_HOUSE:
						s.sprite = HauntedHouse;
							if (stores == null)
								stores = new Dictionary<Pair, Store>();
							Debug.Log (x + " " + y);
						stores.Add(new Pair(x, y), new Store(true));
		    			  break;
   					  case STORE:
						s.sprite = Store;
						if (stores == null)
							stores = new Dictionary<Pair, Store>();
						Debug.Log (x + " " + y);
						stores.Add(new Pair(x, y), new Store(true));
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
			return current[location.Y, location.X];
		}
		catch (IndexOutOfRangeException e)
		{
			return 9999;
		}
		
	}
}
