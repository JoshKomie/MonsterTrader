﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Catalog : MonoBehaviour 
{
	private static List<AbstractItem> catalog;
	private static bool initialized = false;
	private static List<Material> metals, woods, leathers;
	private static int variance = 30;
	private static List<ItemType> metalItems, woodenItems, leatherItems;
	
	private static Dictionary<string, AbstractItem> specialItems;
	public static void Init()
	{
		initialized = true;
		catalog = new List<AbstractItem>();
		catalog.Add(new AbstractItem("Bronze Helm", new Pair(20, 80)));
		catalog.Add (new AbstractItem("Bronze Plateguard", new Pair(30, 90)));
		
		metals = new List<Material>();
		metals.Add(new Material("Iron", 1m));
		metals.Add(new Material("Steel", 1.8m));
		metals.Add(new Material("Rubium", 3m));
		metals.Add(new Material("Titium", 6m));
		metals.Add(new Material("Mithrite", 10m));	
		
		woods = new List<Material>();	
		woods.Add (new Material("Oak", 1m));
		woods.Add (new Material("Hickory", 1.5m));
		woods.Add (new Material("Mirkwood", 3m));
		woods.Add (new Material("Rockwood", 6m));
		woods.Add (new Material("Dragon", 10m));
		
		metalItems = new List<ItemType>();
		metalItems.Add(new ItemType("Sword", 50));
		metalItems.Add(new ItemType("Battle Axe", 70));
		metalItems.Add(new ItemType("Helm", 40));
		metalItems.Add(new ItemType("Armor", 60));
		
		woodenItems = new List<ItemType>();
		woodenItems.Add(new ItemType("Bow", 50));
		woodenItems.Add(new ItemType("Staff", 70));
		woodenItems.Add(new ItemType("Arrows", 40));
		
		
		
		
		specialItems = new Dictionary<string, AbstractItem>();
		specialItems.Add("Dwarf", new AbstractItem("Dwarven Forge of Persistance", new Pair(300, 500)));
		specialItems.Add ("Wood Elf", new AbstractItem("Ranger's Bow", new Pair(200, 400)));
		specialItems.Add ("Druid", new AbstractItem("Druidic Essence of Nature", new Pair(300, 500)));
		specialItems.Add ("Dryad", new AbstractItem("Magic Tree Seeds", new Pair(300, 600)));
		specialItems.Add ("Troll", new AbstractItem("Fearsome Troll's Club", new Pair(200, 600)));	
		specialItems.Add ("Human", new AbstractItem("Filled to the brim Treasure Chest", new Pair(200, 600)));	
		specialItems.Add ("Mermaid", new AbstractItem("Mermaid's Tiara", new Pair(400, 800)));
		specialItems.Add ("Snake", new AbstractItem("Snake's Tooth", new Pair(200, 300)));
		specialItems.Add ("Key", new AbstractItem("Mysterious Key", new Pair(200, 300)));
		
	}
	
	public static AbstractItem SpecialItem(string key)
	{
		return specialItems[key];
	}
	public static AbstractItem RandomMetalItem(int level)
	{
		if (!initialized)
			Init ();
		Material m = metals[level];
		ItemType i = metalItems[Random.Range(0, metalItems.Count)];
		int cost  = (int)Mathf.Round(((float)i.BaseCost * (float)m.Modifier));
		//Debug.Log ("bse" + i.BaseCost + "mod: " + m.Modifier + " cost: " + cost);
		return new AbstractItem(m.Name + " " + i.Name, new Pair(cost - variance, cost + variance));
		
	}
	public static AbstractItem RandomWoodItem(int level)
	{
		if (!initialized)
			Init ();
		Material m = woods[level];
		ItemType i = woodenItems[Random.Range(0, woodenItems.Count)];
		int cost  = (int)Mathf.Round(((float)i.BaseCost * (float)m.Modifier));
		//Debug.Log ("bse" + i.BaseCost + "mod: " + m.Modifier + " cost: " + cost);
		return new AbstractItem(m.Name + " " + i.Name, new Pair(cost - variance, cost + variance));
		
	}
	
	
	public static AbstractItem RandomItem(int level)
	{
		if (!initialized)
			Init ();
		float levelRoll = Random.value;
		if (levelRoll < .2f)
		{
			level--;
			if (level < 0)
				level = 0;
		}
		else if (levelRoll > .8f)
		{
			level++;
			if (level > 4)
				level = 4;
		}
		
		if (Random.value < .5f)
		{
			return RandomMetalItem(level);
		}
		else
		{
			return RandomWoodItem(level);
		}
	}
	
	//better system - have a list of metals, and a list of items, and each has modifiers to the low and high
}
