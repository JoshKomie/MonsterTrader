using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Global 
{
	private static ushort tILE_SIZE = 1;
	private static Tiles tiles;
	private static Trader player;
	private static GoldInterface gold;

	public static GoldInterface Gold {
		get {
			if (gold == null)
			{
				gold = GameObject.Find ("Gold").GetComponent<GoldInterface>();
			}
			return gold;
		}
	}

	public static Trader Player {
		get {
			if (player == null)
				player= GameObject.Find ("Player").GetComponent<Trader>();
			return player;
		}
	}
	
	public static Tiles Tiles {
		get {
			if (tiles == null)
				tiles = GameObject.Find ("Tiles").GetComponent<Tiles>();
			return tiles;
		}
	}

	public static ushort TILE_SIZE {
		get {
			return tILE_SIZE;
		}
	}
}
