using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Item 
{
	private string name;
	private int quantity;
	private int price;
	private bool rare;
	private float goodDeal;
	public Item (string name, int quantity, int price, float goodDeal = .5f, bool rare = false)
	{
		this.name = name;
		this.quantity = quantity;
		this.price = price;
		this.rare = rare;
		this.goodDeal = goodDeal;
	}
	
	public Item(Item old)
	{
		name = old.name;
		quantity = old.quantity;
		price = old.price;
		rare = old.rare;
		goodDeal = old.goodDeal;
	}
	
	public override bool Equals (object obj)
	{
		if (obj == null)
			return false;
		if (ReferenceEquals (this, obj))
			return true;
		if (obj.GetType () != typeof(Item))
			return false;
		Item other = (Item)obj;
		return (name == other.name && price == other.price);
	}
	
	public bool EqualsByName(Item item)
	{
		Debug.Log (item.rare.ToString() +  rare.ToString());
		return name == item.name || (item.rare && rare);
	}
	

	public override int GetHashCode ()
	{
		unchecked {
			return (name != null ? name.GetHashCode () : 0) ^ price.GetHashCode ();
		}
	}
	
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	public int Quantity {
		get {
			return quantity;
		}
		set {
			quantity = value;
		}
	}
	

	public int Price
	{
		get
		{
			return this.price;
		}
	}	

	public bool Rare {
		get {
			return rare;
		}
	}

	public float GoodDeal {
		get {
			return goodDeal;
		}
	}
}
