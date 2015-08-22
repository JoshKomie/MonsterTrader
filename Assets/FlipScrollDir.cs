using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FlipScrollDir : MonoBehaviour 
{
	public void Start()
	{
		GetComponent<Scrollbar>().SetDirection(Scrollbar.Direction.TopToBottom, true);
	}
}
