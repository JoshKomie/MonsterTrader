using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Encounter
{
	private string mainText;
	
	
	public Encounter (string mainText)
	{
		this.mainText = mainText;
		
	}
	
	public string MainText
	{
		get
		{
			return this.mainText;
		}
	}
}
