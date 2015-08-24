using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Store
{
	
	
	private List<Item> forSale;
	private List<Item> buying;
	private string name;
	public Store ()
	{
		Debug.Log ("cons called");
		AbstractItem item = Catalog.RandomItem(Global.Level);
		forSale = new List<Item>();	
		buying = new List<Item>();
		/*forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));
		
		item = Catalog.RandomItem(Global.Level);
		forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));*/
		
		
		for (int i = 0; i < 5; i++)
		{
			item = Catalog.RandomItem(Global.Level);
			int price = Random.Range(item.PriceRange.X, item.PriceRange.Y);
			float goodDeal = (float)(price - item.PriceRange.X) / (float)(item.PriceRange.Y - item.PriceRange.X);
			forSale.Add(new Item(item.Name, Random.Range(1, 5), price, goodDeal));
		}
		for (int i = 0; i <5; i++)
		{
			item = Catalog.RandomItem(Global.Level);
			int price = Random.Range(item.PriceRange.X, item.PriceRange.Y);
			float goodDeal = (float)(price - item.PriceRange.X) / (float)(item.PriceRange.Y - item.PriceRange.X);
			buying.Add(new Item(item.Name, 0, price, goodDeal));
		}
		
		
	}
	
	public Store Copy()
	{
		Debug.Log ("copy created");
		Store copy = new Store();
		copy.forSale = forSale;
		copy.forSale[0].Quantity = 1;
		copy.buying = buying;
		copy.name = name;
		return copy;
	}
	
	public Store(string special)
	{
		forSale = new List<Item>();	
		buying = new List<Item>();
		AbstractItem item;
		switch (special)
		{
			case "Dwarf":
				item = Catalog.SpecialItem("Dwarf");
				
				forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y), 2f,  true));
				//name = "Dwarven Store";
				break;
		case "Wood Elf":
			//name = "Elven Store";
			item = Catalog.SpecialItem("Wood Elf");
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y), 2f, true));
			break;
		case "Druid":
			//name = "Bartering Druids";
			item = Catalog.SpecialItem("Druid");
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y),2f,  true));
			break;
		case "Human":
			item = Catalog.SpecialItem("Human");
			
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y), 2f,  true));
			//name = "Dwarven Store";
			break;
		case "Key":
			//name = "Elven Store";
			item = Catalog.SpecialItem("Key");
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y), 2f, true));
			break;
		case "Dryad":
			//name = "Bartering Druids";
			item = Catalog.SpecialItem("Dryad");
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y),2f,  true));
			break;
		case "Troll":
			//name = "Bartering Druids";
			item = Catalog.SpecialItem("Troll");
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y),2f,  true));
			break;
		case "Mermaid":
			//name = "Bartering Druids";
			item = Catalog.SpecialItem("Mermaid");
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y),2f,  true));
			break;
		case "Snake":
			//name = "Bartering Druids";
			item = Catalog.SpecialItem("Snake");
			forSale.Add(new Item(item.Name, 1, Random.Range(item.PriceRange.X, item.PriceRange.Y),2f,  true));
			break;
		
		}
		for (int i = 0; i < 1; i++)
		{
			item = Catalog.RandomItem(Global.Level);
			int price = Random.Range(item.PriceRange.X, item.PriceRange.Y);
			float goodDeal = (float)(price - item.PriceRange.X) / (float)(item.PriceRange.Y - item.PriceRange.X);
			forSale.Add(new Item(item.Name, Random.Range(1, 5), price, goodDeal));
		}
		for (int i = 0; i < 3; i++)
		{
			item = Catalog.RandomItem(Global.Level);
			int price = Random.Range(item.PriceRange.X, item.PriceRange.Y);
			float goodDeal = (float)(price - item.PriceRange.X) / (float)(item.PriceRange.Y - item.PriceRange.X);
			buying.Add(new Item(item.Name, 0, price, goodDeal));
		}
		
	}
	public Store(bool buyingSpecial)
	{
		Debug.Log ("cons called");
		AbstractItem item = Catalog.RandomItem(Global.Level);
		forSale = new List<Item>();	
		buying = new List<Item>();
		/*forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));
		
		item = Catalog.RandomItem(Global.Level);
		forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));*/
		
		
		for (int i = 0; i < 5; i++)
		{
			item = Catalog.RandomItem(Global.Level);
			int price = Random.Range(item.PriceRange.X, item.PriceRange.Y);
			float goodDeal = (float)(price - item.PriceRange.X) / (float)(item.PriceRange.Y - item.PriceRange.X);
			Debug.Log (price - item.PriceRange.X);
			forSale.Add(new Item(item.Name, Random.Range(1, 5), price, goodDeal));
		}
		for (int i = 0; i < 4; i++)
		{
			item = Catalog.RandomItem(Global.Level);
			int price = Random.Range(item.PriceRange.X, item.PriceRange.Y);
			float goodDeal = (float)(price - item.PriceRange.X) / (float)(item.PriceRange.Y - item.PriceRange.X);
			buying.Add(new Item(item.Name, 0, price, goodDeal));
		}
		buying.Add (new Item("Any rare or unique item!", 0, Random.Range(400, 1000), 2f,  true));
	}
	
	
	
	public Item BuyAt(int position)
	{
	//	Debug.Log ("Calling buy at");
		Item item;
		if (forSale == null)
			return null;
		item = new Item(forSale[position]);
		if (forSale[position].Quantity == 0)
		{
			//forSale.Remove(forSale[position]);
		}
		else
		{
//			Debug.Log ("subbing " + forSale[position].Quantity);
			
			forSale[position].Quantity--;
//			Debug.Log ("subbing " + forSale[position].Quantity);
		}
		return item;
	}
	
	public int SellAt(int position)
	{
		return buying[position].Price;
	}
	
	
	
	

	public List<Item> ForSale {
		get {
			return forSale;
		}
	}

	public List<Item> Buying {
		get {
			return buying;
		}
	}
}
