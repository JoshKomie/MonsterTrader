using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Store
{
	
	
	private List<Item> forSale;
	private List<Item> buying;
	
	public Store ()
	{
		Debug.Log ("cons called");
		AbstractItem item = Catalog.RandomItem();
		forSale = new List<Item>();	
		
		forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));
		
		item = Catalog.RandomItem();
		forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));
		
		buying = new List<Item>();
		item = Catalog.RandomItem();
		buying.Add(new Item(item.Name, 0, Random.Range(item.PriceRange.X, item.PriceRange.Y)));
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
