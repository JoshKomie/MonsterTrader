using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DraggableWindow : MonoBehaviour 
{
	private Vector3 offset;
	
	public void OnPointerDown()
	{
		offset = transform.position - UnityEngine.Input.mousePosition;
	}
	public void OnDrag()
	{
		transform.position = UnityEngine.Input.mousePosition + offset;
	}
}
