using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemInterface : MonoBehaviour 
{
	private Item item;
	private ushort index;
	private TradeWindow parentWindow;
	private Text name, quantity, price, priceRange;
	public void Init(Item item, ushort index, TradeWindow parentWindow)
	{
		this.item = item;
		this.parentWindow = parentWindow;
		name = transform.FindChild("Item Name").GetComponent<Text>();
		
		Transform q = transform.FindChild("Quantity");
		if (q != null)
		{
			quantity = q.GetComponent<Text>();
		}
		
		price = transform.FindChild("Price").GetComponent<Text>();
		
		Transform t = transform.FindChild("PriceRange");
		if (t != null)
		{
			priceRange = t.GetComponent<Text>();
		}
		
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
			GlobalSound.Play(SOUNDS.NEGATIVE);
		}
		
		
	}
	
	public void Sell()
	{
		if (Global.Player.Has(item))
		{
			Global.Player.Gold += parentWindow.SellAt(index);
			Global.Player.TakeItem(item);
		}
		else
		{
			Debug.Log ("player doesnt have item");
			GlobalSound.Play(SOUNDS.NEGATIVE);
		}
	}
	
	private void updateText()
	{
		name.text = item.Name;
		if (quantity != null)
		{
			quantity.text = item.Quantity.ToString();
		}
		
		price.text = item.Price.ToString();
		if (priceRange != null)
		{
			Debug.Log (item.GoodDeal);
			priceRange.text = item.GoodDeal.ToString();
		}
		
	}
}
