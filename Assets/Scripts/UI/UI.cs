using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour 
{
	private static GameObject tradeWindow;
	private static GameObject tradeMessage;
	private static GameObject inventoryWindow;
	private static bool tradeMessageUp;
	private static bool hasReferences = false;
	
	private static UI instance;
	public void Awake()
	{
		instance = this;
	}
	public void Start()
	{
		if (!hasReferences)
		{
			getReferences();
		}
		
	}
	
	private void getReferences()
	{
		tradeWindow = transform.FindChild("BuySellPanel").gameObject;
		tradeMessage = transform.FindChild("TradeMessage").gameObject;
		inventoryWindow = transform.FindChild("InventoryWindow").gameObject;
		
		SetTradeMessageVis(false);
		SetTradeWindowVis(false);
		SetInventoryWindowVis(false);
		hasReferences = true;
	}
	public static void SetTradeMessageVis(bool target)
	{
		tradeMessage.SetActive(target);
		tradeMessageUp = target;
	}
	
	public static void SetTradeWindowVis(bool target)
	{
		if (target == true)
		{
			if (tradeMessage)
			{
				tradeWindow.SetActive(target);
				
			}	
		}
		else
			tradeWindow.SetActive(target);
			
	}
	
	public static void SetInventoryWindowVis(bool target)
	{
		inventoryWindow.SetActive(target);
	}
	
	public static void ShowTradeWindow(Store store)
	{
		if (tradeMessageUp)
		{
			SetTradeWindowVis(true);
			List<Item> items = store.ForSale;
			tradeWindow.GetComponent<TradeWindow>().Init(items, store);
		}
		
	}
	
	
	
	public static void UpdateInventory(List<Item> items)
	{
		if (!hasReferences)
			instance.getReferences();
		if (inventoryWindow.gameObject.activeInHierarchy)
			inventoryWindow.GetComponent<InventoryWindow>().Init(items);
	}
	
	
	
	
}
