using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour 
{
	private static GameObject tradeWindow;
	private static GameObject tradeMessage;
	private static GameObject inventoryWindow;
	private static GameObject encounterWindow;
	private static GameObject goodDealHelp;
	
	private static bool tradeMessageUp;
	private static bool hasReferences = false;
	
	private static UI instance;
	public void Awake()
	{
		instance = this;
	}
	public void Start()
	{
		Debug.Log ("startwcalled");
		hasReferences = false;
		if (!hasReferences)
		{
			getReferences();
		}
		
	}
	
	/*public void OnLevelWasLoaded(int i )
	{
		Debug.Log ("called");
		if (!hasReferences)
			getReferences();
	}*/
	
	private void getReferences()
	{
		Debug.Log ("UI getting ref");
		tradeWindow = transform.FindChild("BuySellPanel").gameObject;
		tradeMessage = transform.FindChild("TradeMessage").gameObject;
		inventoryWindow = transform.FindChild("InventoryWindow").gameObject;
		encounterWindow = transform.FindChild("Encounter").gameObject;
		goodDealHelp = transform.FindChild("GoodDealHelp").gameObject;
		Debug.Log (inventoryWindow);
		SetTradeMessageVis(false);
		SetTradeWindowVis(false);
		SetInventoryWindowVis(false);
		SetEncounterWindowVis(false);
		SetGoodDealVis(false);
		hasReferences = true;
	}
	
	public static void SetGoodDealVis(bool target)
	{
		goodDealHelp.SetActive(target);
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
	
	public static void SetEncounterWindowVis(bool target)
	{
		encounterWindow.SetActive(target);
	}
	
	public static void InitiateEncounter(AdventurerGroup group)
	{
		SetEncounterWindowVis(true);
		encounterWindow.GetComponent<EncounterWindow>().Init(group);
		
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
		if (inventoryWindow != null && inventoryWindow.activeInHierarchy)
			inventoryWindow.GetComponent<InventoryWindow>().Init(items);
	}
	
	
	
	
}
