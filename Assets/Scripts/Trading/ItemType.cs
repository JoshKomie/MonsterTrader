using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemType
{
	private string name;
	private int baseCost;
	public ItemType (string name, int baseCost)
	{
		this.name = name;
		this.baseCost = baseCost;
	}
	
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	public int BaseCost
	{
		get
		{
			return this.baseCost;
		}
	}
}
