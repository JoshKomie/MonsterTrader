using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AbstractItem
{
	private string name;
	private Pair priceRange;
	
	public AbstractItem (string name, global::Pair priceRange)
	{
		this.name = name;
		this.priceRange = priceRange;
	}
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	public Pair PriceRange
	{
		get
		{
			return this.priceRange;
		}
	}
}
