using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryItem : MonoBehaviour 
{
	private Item item;
	private ushort index;
	private Text name, quantity, price;
	public void Init(Item item)
	{
		this.item = item;
		name = transform.FindChild("Item Name").GetComponent<Text>();
		quantity = transform.FindChild("Quantity").GetComponent<Text>();
		price = transform.FindChild("Price").GetComponent<Text>();
		updateText();
		this.index = index;
	}
	
	private void updateText()
	{
		name.text = item.Name;
		quantity.text = item.Quantity.ToString();
		price.text = item.Price.ToString();
	}
}
