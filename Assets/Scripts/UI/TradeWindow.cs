using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TradeWindow : MonoBehaviour 
{
	public GameObject ItemPanel;
	public GameObject BuyInterface;
	private GameObject forSalePanel;
	private GameObject buyingPanel;
	private int itemInterfaceOffset = 0;
	private int itemInterfaceDistance = 25;
	private List<GameObject> currentInterfaces;
	private Store currentStore;
	
	public void Close()
	{
		UI.SetTradeWindowVis(false);
	}
	
	public Item BuyAt(ushort index)
	{
		return currentStore.BuyAt(index);
	}
	
	public int SellAt(ushort index)
	{
		return currentStore.SellAt(index);
	}
	
	public void Init(List<Item> items, Store store)
	{
		if (currentInterfaces == null)
			currentInterfaces = new List<GameObject>();
		else
		{
			foreach (GameObject g in currentInterfaces)
			{
				Destroy(g);
			}
			currentInterfaces.Clear();
			itemInterfaceOffset = 0;
		}
		
		currentStore = store;
		forSalePanel = transform.Find("ForSale").gameObject;
		ushort index=  0;
		foreach (Item i in items)
		{
			GameObject itemInterface = Instantiate(ItemPanel) as GameObject;
			itemInterface.transform.position = new Vector2(itemInterface.transform.position.x , itemInterface.transform.position.y- itemInterfaceOffset);
			itemInterfaceOffset += itemInterfaceDistance;
			itemInterface.transform.SetParent(forSalePanel.transform, false);
			itemInterface.GetComponent<ItemInterface>().Init(i, index, this);
			currentInterfaces.Add(itemInterface);
			index++;
		}
		
		buyingPanel = transform.Find("Buying").gameObject;
		index=  0;
		itemInterfaceOffset = 0;
		foreach (Item i in currentStore.Buying)
		{
			GameObject itemInterface = Instantiate(BuyInterface) as GameObject;
			itemInterface.transform.position = new Vector2(itemInterface.transform.position.x , itemInterface.transform.position.y- itemInterfaceOffset);
			itemInterfaceOffset += itemInterfaceDistance;
			itemInterface.transform.SetParent(buyingPanel.transform, false);
			itemInterface.GetComponent<ItemInterface>().Init(i, index, this);
			currentInterfaces.Add(itemInterface);
			index++;
		}
		
		
		
	}
}
