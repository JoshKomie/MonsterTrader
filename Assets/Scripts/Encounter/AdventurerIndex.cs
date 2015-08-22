using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AdventurerIndex : MonoBehaviour 
{
	private static List<AdventurerGroup> forest;
	private static List<AdventurerGroup> mountain;
	
	public void Start()
	{
		forest = new List<AdventurerGroup>();
		forest.Add(new AdventurerGroup("Band of Dwarves", "The dwarves draw their battleaxes and charge!", "The dwarves take out their packs and gather round", null, 4));
		forest.Add(new AdventurerGroup("Group of Night Elves", "The Night Elves disappear into the trees, drawing their bows", "The night elf leader comes forward, pulling out a sack of goods", null, 5));
	}
	
	public static AdventurerGroup RandomForest()
	{
		return forest[Random.Range(0, forest.Count)];
	}
	
}
