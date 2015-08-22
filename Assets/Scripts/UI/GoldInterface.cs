using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GoldInterface : MonoBehaviour 
{
	private Text text;
	
	
	public void ValueChanged(int newVal)
	{
		if (text == null)
		{
			text = transform.FindChild("Text").GetComponent<Text>();
		}
		text.text = newVal.ToString();
	}
}
