using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelTime : MonoBehaviour 
{
	private Image bg;
	private Transform sun;
	private float totalTime = 20f;
	private float elapsedTime= 0f;
	private float ratioTime, halfRatio;
	public Transform start, end;
	public Color startC, midC;
	public void Start()
	{
		bg = GetComponent<Image>();
		sun = transform.FindChild("Sun");
	}
	
	public void Update()
	{
		elapsedTime += Time.deltaTime;
		ratioTime = elapsedTime / totalTime;
		
		sun.transform.position = Vector2.Lerp(start.position, end.position, ratioTime);
		
		
		bg.color = Color.Lerp(midC, startC, ratioTime);
			
		if (elapsedTime >= totalTime)
		{
			finishlevel();
		}
	}
	private void finishlevel()
	{
		Global.EndLevel(Global.Player.Gold);
	}
}
