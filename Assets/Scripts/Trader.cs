using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Trader : MonoBehaviour 
{
	private ushort isOverTile;
	private Pair pos;
	private Store currentStore;
	public void Start()
	{
		
	}
	public void Update()
	{
		movement();
		input ();
	}
	
	private void movement()
	{
		bool moved = false;
		if (Input.GetButtonDown("Right"))
		{
			transform.position = new Vector2( transform.position.x + Global.TILE_SIZE, transform.position.y);
			moved = true;
		}
		else if (Input.GetButtonDown("Left"))
		{
			transform.position = new Vector2( transform.position.x - Global.TILE_SIZE, transform.position.y);
			moved = true;
		}
		else if (Input.GetButtonDown("Up"))
		{
			transform.position = new Vector2( transform.position.x , transform.position.y + Global.TILE_SIZE);
			moved = true;
		}
		else if (Input.GetButtonDown("Down"))
		{
			transform.position = new Vector2( transform.position.x, transform.position.y  - Global.TILE_SIZE);
			moved = true;
		}
		
		
		if (moved)
		{
			postMove();
		}
	}
	
	private void input()
	{
		if (Input.GetButtonDown("Trade"))
		{
			Debug.Log ("trade r");
			UI.ShowTradeWindow(currentStore.ForSale);
		}
	}
	private void postMove()
	{
		pos = new Pair(transform.position.x, transform.position.y);
		isOverTile = Global.Tiles.TileAt(pos);
		switch (isOverTile)
		{
			case Tiles.STORE:
				currentStore = Global.Tiles.StoreAt(pos);
				UI.SetTradeMessageVis(true);
				break;
			default:
				UI.SetTradeMessageVis(false);
				break;
		}
	}
	
	
}
