using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemInterface : MonoBehaviour 
{
	private Item item;
	private ushort index;
	private TradeWindow parentWindow;
	private Text name, quantity, price;
	public void Init(Item item, ushort index, TradeWindow parentWindow)
	{
		this.item = item;
		this.parentWindow = parentWindow;
		name = transform.FindChild("Item Name").GetComponent<Text>();
		quantity = transform.FindChild("Quantity").GetComponent<Text>();
		price = transform.FindChild("Price").GetComponent<Text>();
		updateText();
		this.index = index;
	}
	
	public void Buy()
	{
		if (Global.Player.Gold >= item.Price)
		{
			Global.Player.GiveItem(parentWindow.BuyAt(index));
			updateText();
		}
		else
		{
			Debug.Log ("not enough gold");
		}
		
		
	}
	
	private void updateText()
	{
		name.text = item.Name;
		quantity.text = item.Quantity.ToString();
		price.text = item.Price.ToString();
	}
}
