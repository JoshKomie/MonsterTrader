using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChooseMonster : MonoBehaviour 
{
	private AsyncOperation a;
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
			Debug.Log (a.progress);
		
	}
}
