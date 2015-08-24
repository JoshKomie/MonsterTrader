using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelEnd : MonoBehaviour 
{
	public static int[] owed = {300, 500, 700, 1000, 1500};
	public void Start()
	{
		Init (Global.GoldFromLast);
	}
	public void Init(int goldEarned)
	{
		int amtOwed = owed[Global.Level];
		
		if (goldEarned == 0)
		{
			GameObject.Find ("Title").GetComponent<Text>().text = "You died!";
			GameObject.Find("Earned").GetComponent<Text>().text = "All of your gold was lost on death.";
		}
		else
		{
			GameObject.Find("Earned").GetComponent<Text>().text = "You earned " + goldEarned.ToString() + " gold.";
		}	
		
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
		
		if (Global.Level == 4)
		{
			GameObject.Find ("Title").GetComponent<Text>().text = "Game complete!";
			GameObject.Find ("Success").GetComponent<Text>().text= "Congratulations! you have paid back all your debt to the Necromancer!";
			GameObject.Find("Continue").SetActive(false);
		}
	}
	
	public void Continue()
	{
		Global.Level++;
		Application.LoadLevel("Level");
		s.gameObject.SetActive(true);
		//Global.InitLevel(Global.Level);
		
	}
	
	public void Restart()
	{
		Application.LoadLevel("Level");
		s.gameObject.SetActive(true);
		//Global.InitLevel(Global.Level);
		
	}
	
	public void MainMenu()
	{
		Application.LoadLevel("ChooseMonster");
	}
	
	public Slider s;
}
