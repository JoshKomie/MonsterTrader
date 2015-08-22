using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Catalog : MonoBehaviour 
{
	private static List<AbstractItem> catalog;
	private static bool initialized = false;
	public static void Init()
	{
		initialized = true;
		catalog = new List<AbstractItem>();
		catalog.Add(new AbstractItem("Bronze Helm", new Pair(20, 80)));
		catalog.Add (new AbstractItem("Bronze Plateguard", new Pair(30, 90)));
		
	}
	
	
	public static AbstractItem RandomItem()
	{
		if (!initialized)
			Init ();
		return catalog[Random.Range(0, catalog.Count)];
	}
	
	//better system - have a list of metals, and a list of items, and each has modifiers to the low and high
}
