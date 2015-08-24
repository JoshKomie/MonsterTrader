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
	private static HealthInterface health;
	private static int level = 0;
	
	private static int goldFromLast;
	private static int goldForNext = 0;
	public static HealthInterface Health {
		get {
			if (health == null)
				health = GameObject.Find ("Health").GetComponent<HealthInterface>();
			return health;
		}
	}
	
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
	public static void SetPlayerLoc(int x, int y)
	{
		Player.Respawn(x, y);
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

	public static int Level {
		get {
			return level;
		}
		set { level = value; }
	}
	
	public static void EndLevel(int gold)
	{
		Application.LoadLevel("LevelEnd");
		goldFromLast = gold;
	}

	public static void InitLevel(int level)
	{
		if (tiles == null)
			tiles = GameObject.Find ("Tiles").GetComponent<Tiles>();
		tiles.BuildLevel(level);
	}
	public static int GoldFromLast {
		get {
			return goldFromLast;
		}
	}

	public static int GoldForNext {
		get {
			return goldForNext;
		}
		set {
			goldForNext = value;
		}
	}
}
