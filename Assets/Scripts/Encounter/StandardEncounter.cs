using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StandardEncounter : Encounter
{
	private AdventurerGroup adventurerGroup;
	private string main = "You encounter a ";
	
	public StandardEncounter (AdventurerGroup adventurerGroup): base("You encounter a " + adventurerGroup.Name)
	{
		this.adventurerGroup = adventurerGroup;
	}
	
}
