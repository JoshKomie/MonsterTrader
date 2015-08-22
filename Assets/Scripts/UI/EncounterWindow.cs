using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EncounterWindow : MonoBehaviour 
{
	private Text main;
	private Text followUp;
	
	
	public void SetMainText(string text)
	{
		if (main == null)
			main = transform.FindChild("MainText").GetComponentInChildren<Text>();
		main.text = text;
	}
	
	public void SetFollowUpText(string text)
	{
		if (followUp == null)
			followUp = transform.FindChild("Result Text").GetComponentInChildren<Text>();
		followUp.text = text;
	}
	
	public void ToggleMode(bool initial)
	{
		
	}
}
