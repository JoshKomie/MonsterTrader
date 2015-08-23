using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelEnd : MonoBehaviour 
{
	public void Start()
	{
		Init (Global.GoldFromLast);
	}
	public void Init(int goldEarned)
	{
		int amtOwed = 500;
		GameObject.Find("Earned").GetComponent<Text>().text = "You earned " + goldEarned.ToString() + " gold.";
		GameObject.Find ("Owed").GetComponent<Text>().text = "You owe " + amtOwed.ToString() + " to the Necromancer";
		if (goldEarned >= amtOwed)
		{
			int bonus = goldEarned - amtOwed;
			GameObject.Find ("Success").GetComponent<Text>().text= "Level Complete! And you get to keep " + bonus.ToString() + "gold!";
			GameObject.Find("Failed").SetActive(false);
			GameObject.Find ("Retry").SetActive(false); 
			Global.GoldForNext = bonus;
			
		}
		else
		{
			GameObject.Find("Success").SetActive(false);
	//			GameObject.Find ("Failure").GetComponent<Text>().text = "Level failed! You must earn at least 500 gold by nightfall to pay off your debts.";
			GameObject.Find("Continue").SetActive(false);
			
		}
	}
	
	public void Continue()
	{
		Global.Level++;
		Application.LoadLevel("Level");
		//Global.InitLevel(Global.Level);
		
	}
	
	public void Restart()
	{
		Application.LoadLevel("Level");
		//Global.InitLevel(Global.Level);
		
	}
}
