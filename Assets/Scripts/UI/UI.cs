using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour 
{
	private static GameObject tradeWindow;
	private static GameObject tradeMessage;
	private static bool tradeMessageUp;
	
	public void Start()
	{
		tradeWindow = transform.FindChild("BuySellPanel").gameObject;
		tradeMessage = transform.FindChild("TradeMessage").gameObject;
		SetTradeMessageVis(false);
		SetTradeWindowVis(false);
		
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
	
	public static void ShowTradeWindow(List<Item> items)
	{
		SetTradeWindowVis(true);
		tradeWindow.GetComponent<TradeWindow>().Init(items);
	}
	
	
	
	
}
