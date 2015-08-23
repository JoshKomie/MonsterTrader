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
	private int startingGold = 600;
	private decimal combatProficiency = .4m;
	private decimal fleeSuccessChange = .8m;
	private ushort currentHealth;
	private ushort startingHealth = 15;
	public void Start()
	{
		if (inventory == null)
			inventory = new List<Item>();
		updateInventory();
		gold = startingGold + Global.GoldForNext;
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
			inventory.Add(new Item(item.Name, 1, item.Price));
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
			inventory[index].Quantity -= 1;	
			removeZeroQuantities();
			updateInventory();
		}
		
	}
	public void TakeItem(Item item)
	{
		foreach (Item i in inventory)
		{
			if (i.Name == item.Name)
			{
				int index = inventory.FindIndex(item.EqualsByName);
				inventory[index].Quantity -= 1;	
				
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
		pos = new Pair(transform.position.x, transform.position.y);
		isOverTile = Global.Tiles.TileAt(pos);
		//handle store stuff
		switch (isOverTile)
		{
			case Tiles.STORE:
				currentStore = Global.Tiles.StoreAt(pos);
				UI.SetTradeMessageVis(true);
				break;
			default:
				UI.SetTradeMessageVis(false);
				UI.SetTradeWindowVis(false);
				break;
		}
		
		//handle encounters
		switch (isOverTile)
		{
			case Tiles.FOREST:
				if (Random.value < Tiles.FOREST_CHANCE)
				{
					UI.InitiateEncounter(AdventurerIndex.RandomForest());
				}
				break;
		}
	}
	
	public void TakeDamage(ushort damage)
	{
		currentHealth -= damage;
		Global.Health.ValueChanged(currentHealth);
		if (currentHealth <= 0)
		{
			die();
		}
	}
	
	private void die()
	{
		Debug.Log ("player dead");
	}
	
	public bool Has(Item i)
	{
		foreach (Item item in inventory)
		{
			if (i.Name == item.Name)
				return true;
		}
		return false;
	}
	
	public int Gold {
		get {
			return gold;
		}
		set {
			gold = value;
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
}
