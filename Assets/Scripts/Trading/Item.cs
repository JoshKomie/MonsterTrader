using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Item 
{
	private string name;
	private int quantity;
	private int price;
	public Item (string name, int quantity, int price)
	{
		this.name = name;
		this.quantity = quantity;
		this.price = price;
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
		return name == other.name && price == other.price;
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
}
