using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Material
{
	private string name;
	private decimal modifier;
	public Material (string name, decimal modifier)
	{
		this.name = name;
		this.modifier = modifier;
	}
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	public decimal Modifier
	{
		get
		{
			return this.modifier;
		}
	}
}
