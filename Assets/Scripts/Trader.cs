using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Trader : MonoBehaviour 
{
	private ushort isOverTile;
	private Pair pos;
	private Store currentStore;
	private List<Item> inventory;
	private int gold;
	private int[] startingGold = {100, 200, 300, 400, 500};
	private decimal combatProficiency = .25m;
	private decimal fleeSuccessChange = .8m;
	private short currentHealth;
	private short startingHealth = 15;
	
	private bool cantMove = false;
	public void Start()
	{
		if (inventory == null)
			inventory = new List<Item>();
		updateInventory();
		gold = startingGold[Global.Level] + Global.GoldForNext;
		currentHealth = startingHealth;
		Global.Gold.ValueChanged(gold);
		Global.Health.ValueChanged(currentHealth);
	}
	public void Update()
	{
		movement();
		input ();
	}
	
	public void GiveItem(Item item)
	{
		if (item.Quantity == 0)
		{
			Debug.Log ("transaction failed, vendor out of stock");
			return;
		}
		//Item item = new Item(vendorItem);
		if (inventory.Contains(item))
		{
			int index = inventory.FindIndex(item.Equals);
			inventory[index].Quantity += 1;	
		}
		else
		{
			
			//Debug.Log("inv didnt contain");
			inventory.Add(new Item(item.Name, 1, item.Price, item.GoodDeal, item.Rare));
		}
		updateInventory();
		Gold -= item.Price;
		//Debug.Log (inventory.Count);
	}
	public void TakeItemByPrice(Item item)
	{
		if (inventory.Contains(item))
		{
			int index = inventory.FindIndex(item.Equals);
			if (inventory[index].Quantity > 0)
			{
				inventory[index].Quantity -= 1;	
			}
			
			removeZeroQuantities();
			updateInventory();
		}
		
	}
	public void TakeItem(Item item)
	{
		foreach (Item i in inventory)
		{
			if (i.EqualsByName(item))
			{
				int index = inventory.FindIndex(item.EqualsByName);
				if (inventory[index].Quantity > 0)
				{
					inventory[index].Quantity -= 1;	
				}
				
				//updateInventory();
			}
		}
		updateInventory();
		removeZeroQuantities();
		
	}
	
	private void removeZeroQuantities()
	{
		List<Item> itemsToRemove = new List<Item>();
		foreach (Item i in inventory)
		{
			if (i.Quantity == 0)
				itemsToRemove.Add(i);
		}
		foreach (Item r in itemsToRemove)
		{
			inventory.Remove(r);
		}
	}
	
	public void Respawn(int x, int y)
	{
		transform.position = new Vector2(x * Global.TILE_SIZE, y * Global.TILE_SIZE);
		currentHealth = startingHealth;
		
	}
	
	private void movement()
	{
		bool moved = false;
		if (cantMove)
		{
			return;
		}
		if (Input.GetButtonDown("Right"))
		{
			transform.position = new Vector2( transform.position.x + Global.TILE_SIZE, transform.position.y);
			moved = true;
			//transform.localScale = new Vector3(1f , 1f, 1f);
		}
		else if (Input.GetButtonDown("Left"))
		{
			transform.position = new Vector2( transform.position.x - Global.TILE_SIZE, transform.position.y);
			moved = true;
			//transform.localScale = new Vector3(1f , 1f, 1f);
		}
		else if (Input.GetButtonDown("Up"))
		{
			transform.position = new Vector2( transform.position.x , transform.position.y + Global.TILE_SIZE);
			moved = true;
			//transform.localScale = new Vector3(1f , 1f, 1f);
		}
		else if (Input.GetButtonDown("Down"))
		{
			transform.position = new Vector2( transform.position.x, transform.position.y  - Global.TILE_SIZE);
			moved = true;
			//transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));
			//transform.localScale = new Vector3(1f , -1f, 1f);
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
		//	Debug.Log ("trade r");
			UI.ShowTradeWindow(currentStore);
		}
		else if (Input.GetButtonDown("Inventory"))
		{
			
			UI.SetInventoryWindowVis(true);
			updateInventory();
		}
	}
	
	private void updateInventory()
	{
		UI.UpdateInventory(inventory);
	}
	private void postMove()
	{
		//cantMove = true;
		pos = new Pair(transform.position.x, transform.position.y);
		isOverTile = Global.Tiles.TileAt(pos);
		//handle store stuff
		switch (isOverTile)
		{
			case Tiles.STORE:
			case Tiles.CASTLE:
			case Tiles.HAUNTED_HOUSE:
				currentStore = Global.Tiles.StoreAt(pos);
				UI.SetTradeMessageVis(true);
				break;
			default:
				UI.SetTradeMessageVis(false);
				UI.SetTradeWindowVis(false);
				break;
		}
		
		
		float moveDelay = Tiles.EMPTY_DELAY;
		//handle encounters
		Debug.Log ("is over" + isOverTile);
		switch (isOverTile)
		{
			case Tiles.FOREST:
				if (Random.value < Tiles.FOREST_CHANCE)
				{
					UI.InitiateEncounter(AdventurerIndex.RandomForest());
				}
				moveDelay = Tiles.FOREST_DELAY;
				break;
			case Tiles.MOUNTAINS:
				moveDelay = Tiles.MOUNTAIN_DELAY;
				if (Random.value < Tiles.MOUNTAIN_CHANCE)
				{
					UI.InitiateEncounter(AdventurerIndex.RandomMountain());
				}
				break;
		case Tiles.SWAMP:
			moveDelay = Tiles.MOUNTAIN_DELAY;
			if (Random.value < Tiles.SWAMP_CHANCE)
			{
				UI.InitiateEncounter(AdventurerIndex.RandomSwamp());
			}
			break;
		case Tiles.LAKE:
			moveDelay = Tiles.MOUNTAIN_DELAY;
			if (Random.value < Tiles.LAKE_CHANCE)
			{
				UI.InitiateEncounter(AdventurerIndex.RandomLake());
			}
			break;
		case Tiles.CAVE:
			moveDelay = Tiles.MOUNTAIN_DELAY;
			if (Random.value < Tiles.CAVE_CHANCE)
			{
				UI.InitiateEncounter(AdventurerIndex.RandomCave());
			}
			break;
  }
  //Invoke ("canMove", moveDelay);
	}
	
	private void canMove()
	{
		cantMove = false;
	}
	public void TakeDamage(short damage)
	{
		currentHealth -= damage;
		Global.Health.ValueChanged(currentHealth);
		GlobalSound.Play(SOUNDS.LOSEHEALTH);
		if (currentHealth <= 0)
		{
			die();
		}
	}
	
	private void die()
	{
		gold = 0;
		Application.LoadLevel("LevelEnd");
	}
	
	public bool Has(Item i)
	{
		bool result = false;
		foreach (Item item in inventory)
		{
			if (i.EqualsByName(item) && item.Quantity > 0)
				result = true;
		}
		Debug.Log ("player has " + result);
		return result;
	}
	
	public int Gold {
		get {
			return gold;
		}
		set {
			int oldG = gold;
			gold = value;
			if (oldG < gold)
				GlobalSound.Play(SOUNDS.COINGET);
			else if (gold < oldG)
				GlobalSound.Play(SOUNDS.COINLOSE);
			if (gold < 0)
			{
				gold = 0;
			}
			Global.Gold.ValueChanged(gold);
		}
	}

	public decimal CombatProficiency {
		get {
			return combatProficiency;
		}
		set {
			combatProficiency = value;
		}
	}

	public decimal FleeSuccessChange {
		get {
			return fleeSuccessChange;
		}
	}

	public bool CantMove {
		get {
			return cantMove;
		}
		set {
			cantMove = value;
		}
	}
}
