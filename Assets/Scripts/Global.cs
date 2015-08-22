using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Global 
{
	private static ushort tILE_SIZE = 1;
	private static Tiles tiles;
	
	
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
