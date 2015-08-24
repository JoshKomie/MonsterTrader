using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AdventurerIndex : MonoBehaviour 
{
	private static List<AdventurerGroup> forest, mountain, lake, swamp, cave;
	
	public Sprite Dwarf;
	public Sprite WoodElf;
	public Sprite HighElf;
	public Sprite Adventurer;
	public Sprite Knight;
	public Sprite Warg;
	public Sprite Wizard;
	public Sprite Monster;
	
	public void Start()
	{
		forest = new List<AdventurerGroup>();
		forest.Add(new AdventurerGroup("band of dwarves", "The dwarves draw their battleaxes and charge!", "The dwarves take out their packs and gather round", new Store("Dwarf"), .25m, Dwarf));
		forest.Add(new AdventurerGroup("group of wood elves", "The Wood Elves disappear into the trees, drawing their bows", "The elf leader comes forward, with a sack of goods for trading.", new Store("Wood Elf"), .25m, WoodElf));
		
		mountain = new List<AdventurerGroup>();
		lake = new List<AdventurerGroup>();
		swamp = new List<AdventurerGroup>();
		cave = new List<AdventurerGroup>();
		
		forest.Add(new AdventurerGroup("dryad", "The dryad bows her head, disappearing into the trees. A swarm of bees appears and buzzes straight towards you.", "The Dryad removes some items from her tree home to trade.", new Store("Dryad"), .1m));
		forest.Add (new AdventurerGroup("clan of druids", "The druids raise their staves and unleash bolts of water and earth", "the druids take out their packs and begin bargaining", new Store("Druid"), .23m));
		forest.Add (new AdventurerGroup("armored knight", "The knight draws his sword", "The knight dismounts and begins trading.", new Store("Human"), .23m));
		
		
		mountain.Add(new AdventurerGroup("lone dwarf", "The dwarf's eyes blaze and before you know it, his axe is upon you", "The dwarf wearily takes out his backpack", new Store("Dwarf"), .3m, Dwarf));
		mountain.Add (new AdventurerGroup("mountain troll", "The troll raises his club and rumbles towards you", "the troll scratches his head, but eventually agrees to trade", new Store("Troll"), .32m));
		mountain.Add (new AdventurerGroup("pack of wolves", "The wolved howl, then bare their teeth, and advance", "The wolves reveal and impressive stock of goods for sale", null, .4m, Warg));
		mountain.Add (new AdventurerGroup("wizard", "A beam of lightning is emitted from the wizards staff!", "The wizard dismounts and begins to trade", new Store("Key"), .4m, Wizard));
		
		lake.Add(new AdventurerGroup("group of mermaids", "The mermaids his and disappear underwater, shooting boiling jets of water back at you", "The mermaids gather around with an array of ocean treasures", new Store("Mermaid"), .25m));
		lake.Add (new AdventurerGroup("giant sea snake", "The snake slithers and wriggles, and begins his assault", "The snake reveals his pack of tradeable goods", new Store("Snake"), .25m));
		
		swamp.Add(new AdventurerGroup("Werewolf", "The werewolf changes into wolf form and charges towards you", "The werewolf is able to stay in human form just long enough to trade with you", null, .25m, Warg));
		swamp.Add (new AdventurerGroup("Slithering Bunyip", "The bunyip quickly changes speed, coming at you with monsterous fangs", "The bunyip regretfully turns, and shows you what he has to offer", new Store("Snake"), .4m, Monster));
		swamp.Add (new AdventurerGroup("Swamp Settlers", "The settlers break out pitchforks and begin advancing", "The settlers breath a sigh of relief and see what you have to trade with", new Store("Human"), .1m, Adventurer));
		swamp.Add (new AdventurerGroup("old witch", "The witch begins casting her spells.", "The witch shows you her stock of items.", null, .1m));
		
		cave.Add(new AdventurerGroup("cave creature", "The cave creature scampers towards you, with an oddly threatening gaze", "The creature reaches into a slimy old barrel, revealing a grubby pack of goods", null, .2m));
		cave.Add(new AdventurerGroup("dragon", "The dragon circles and hisses.", "You nod at the dragon, and you begin exchanging gold.", new Store("Key"), .2m));
	}
	
	public static AdventurerGroup RandomForest()
	{
		return forest[Random.Range(0, forest.Count)];
	}
	
	public static AdventurerGroup RandomMountain()
	{
		return mountain[Random.Range(0, mountain.Count)];
	}
	
	public static AdventurerGroup RandomSwamp()
	{
		return swamp[Random.Range(0, swamp.Count)];
	}
	
	public static AdventurerGroup RandomLake()
	{
		return lake[Random.Range(0, lake.Count)];
	}
	
	public static AdventurerGroup RandomCave()
	{
		return cave[Random.Range(0, cave.Count)];
	}
	
}
