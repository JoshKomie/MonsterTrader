using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Store
{
	
	
	private List<Item> forSale;
	
	
	public Store ()
	{
		AbstractItem item = Catalog.RandomItem();
		forSale = new List<Item>();	
		
		forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));
		
		item = Catalog.RandomItem();
		forSale.Add(new Item(item.Name, Random.Range(1, 5), Random.Range(item.PriceRange.X, item.PriceRange.Y)));
	}
	
	
	
	public void BuyAt(int position)
	{
		if (forSale == null)
			return;
		if (forSale[position].Quantity == 1)
		{
			forSale.Remove(forSale[position]);
		}
		else
		{
			forSale[position].Quantity--;
		}
	}

	public List<Item> ForSale {
		get {
			return forSale;
		}
	}
}
