using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChooseMonster : MonoBehaviour 
{
	private AsyncOperation a;
	public Slider s;
	public void Start()
	{
		s.gameObject.SetActive(false);
	}
	public void Begin()
	{
		StartCoroutine("load");
	}
	
	private IEnumerator load()
	{
		Debug.Log ("started loading");
		a = Application.LoadLevelAsync("Level");
		
		
		yield return a;
		Debug.Log ("finish");
		
	}
	public void Update()
	{
		if (a != null)
		{
			s.gameObject.SetActive(true);
			s.value = a.progress;
		}
		
	}
}
