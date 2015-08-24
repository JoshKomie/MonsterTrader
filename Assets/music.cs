using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class music : MonoBehaviour 
{
	public AudioClip t1, t2;
	
	public Toggle toggle;
	public void Start()
	{
		GetComponent<AudioSource>().clip = (Random.value > .5f? t1 : t2);
		GetComponent<AudioSource>().Play();
	}
	
	public void valChanged()
	{
		if (toggle.isOn)
			GetComponent<AudioSource>().volume = 1f;
		else
			GetComponent<AudioSource>().volume = 0f;
	}
}
