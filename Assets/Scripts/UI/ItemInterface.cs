using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemInterface : MonoBehaviour 
{
	private Item item;
	
	
	private Text name, quantity, price;
	public void Init(Item item)
	{
		this.item = item;
		name = transform.FindChild("Item Name").GetComponent<Text>();
		quantity = transform.FindChild("Quantity").GetComponent<Text>();
		price = transform.FindChild("Price").GetComponent<Text>();
		name.text = item.Name;
		quantity.text = item.Quantity.ToString();
		price.text = item.Price.ToString();
	}
}
