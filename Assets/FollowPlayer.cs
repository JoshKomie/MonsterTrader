using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour 
{
	public void Update()
	{
		transform.position = new Vector3(Global.Player.transform.position.x, Global.Player.transform.position.y, -10f);
		
	}
}
