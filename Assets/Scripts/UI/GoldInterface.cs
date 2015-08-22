using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GoldInterface : MonoBehaviour 
{
	private Text text;
	public void Start()
	{
		text = transform.FindChild("Text").GetComponent<Text>();
		
	}
	
	public void ValueChanged(int newVal)
	{
		text.text = newVal.ToString();
	}
}
