using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TradeWindow : MonoBehaviour 
{
	public GameObject ItemPanel;
	
	private GameObject forSalePanel;
	private int itemInterfaceOffset = 0;
	private int itemInterfaceDistance = 25;
	public void Close()
	{
		UI.SetTradeWindowVis(false);
	}
	
	public void Init(List<Item> items)
	{
		forSalePanel = transform.Find("ForSale").gameObject;
		foreach (Item i in items)
		{
			GameObject itemInterface = Instantiate(ItemPanel) as GameObject;
			itemInterface.transform.position = new Vector2(itemInterface.transform.position.x , itemInterface.transform.position.y- itemInterfaceOffset);
			itemInterfaceOffset += itemInterfaceDistance;
			itemInterface.transform.SetParent(forSalePanel.transform, false);
			itemInterface.GetComponent<ItemInterface>().Init(i);
		}
		
	}
}
