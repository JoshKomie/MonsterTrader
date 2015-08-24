using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowHelp : MonoBehaviour 
{
	private bool moused = false;
	private GameObject goodDeal;
	public void Start()
	{
		goodDeal = GameObject.Find ("GoodDealHelp");
	}
	public void OnPointerEnter()
	{
		UI.SetGoodDealVis(true);
		moused = true;
	}
	public void OnPointerExit()
	{
		UI.SetGoodDealVis(false);
		moused = false;
	}
	
}
