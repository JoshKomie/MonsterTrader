using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelTime : MonoBehaviour 
{
	private Image bg;
	private Transform sun;
	private float totalTime = 450f;
	private float elapsedTime= 0f;
	private float ratioTime, halfRatio;
	public Transform start, end;
	public Color startC, midC;
	private bool started = false;
	private GameObject endEarly;
	public void Start()
	{
		bg = GetComponent<Image>();
		sun = transform.FindChild("Sun");
		endEarly = GameObject.Find ("EndEarly");
	}
	
	public void Init()
	{
		started = true;
	}
	
	public void Update()
	{
		if (started)
			elapsedTime += Time.deltaTime;
		ratioTime = elapsedTime / totalTime;
		
		sun.transform.position = Vector2.Lerp(start.position, end.position, ratioTime);
		
		
		bg.color = Color.Lerp(midC, startC, ratioTime);
			
		if (elapsedTime >= totalTime)
		{
			finishlevel();
		}
		
		if (Global.Player.Gold > LevelEnd.owed[Global.Level])
		{
			endEarly.GetComponent<Button>().interactable = true;
		}
	}
	public void finishlevel()
	{
		Global.EndLevel(Global.Player.Gold);
	}
}
