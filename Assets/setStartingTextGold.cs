using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class setStartingTextGold : MonoBehaviour 
{
	//GameObject endEarlyButton;
	public void Start()
	{
		transform.FindChild("ObjText").GetComponent<Text>().text = "Collect " + LevelEnd.owed[Global.Level] + " gold by nightfall!";
		transform.FindChild("LevelNameText").GetComponent<Text>().text = "Level " + (Global.Level + 1);
		//endEarlyButton = GameObject.Find ("EndEarly");
		Global.Player.CantMove = true;
	}
	
	public void Remove()
	{
		gameObject.SetActive(false);
		Global.Player.CantMove = false;
		GameObject.FindGameObjectWithTag ("LevelTime").GetComponent<LevelTime>().Init();
	}
}
