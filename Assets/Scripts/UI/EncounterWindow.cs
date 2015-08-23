using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EncounterWindow : MonoBehaviour 
{
	private Text main;
	private Text followUp;
	private AdventurerGroup group;
	private GameObject initialButtons;
	private Pair damageRange;
	private Pair fleeDamage;
	public void Init(AdventurerGroup group)
	{
		this.group = group;
		
		initialButtons = transform.FindChild("MainButtons").gameObject;
		SetMainText("You encounter a " + group.Name + ".");
		SetFollowUpText("What would you like to do?");
		damageRange = new Pair(1, 4);
		fleeDamage = new Pair(1, 2);
		ToggleMode(true);
	}
	public void SetMainText(string text)
	{
		if (main == null)
			main = transform.FindChild("MainText").GetComponentInChildren<Text>();
		main.text = text;
	}
	
	public void SetFollowUpText(string text)
	{
		if (followUp == null)
			followUp = transform.FindChild("Result Text").GetComponentInChildren<Text>();
		followUp.text = text;
	}
	
	public void ToggleMode(bool initial)
	{
		initialButtons.SetActive(initial);
	}
	
	public void Trade()
	{
		ToggleMode(false);
		SetMainText(group.TradeText);
		SetFollowUpText("");
		UI.SetTradeMessageVis(true);
		UI.ShowTradeWindow(new Store());
	}
	
	public void Fight()
	{
		ToggleMode(false);
		SetMainText(group.FightText);
		decimal diff = Global.Player.CombatProficiency - group.CombatProficiency;
		if ((decimal)Random.value < .5m + diff)
		{
			AbstractItem aItem = Catalog.RandomItem(Global.Level);
			Item item = new Item(aItem.Name, 1, 0);
			SetFollowUpText("You win the battle, and the " + group.Name + "offers you " + item.Name + ".");
			Global.Player.GiveItem(item);
		}
		else 
		{
			int damage = Random.Range(damageRange.X, damageRange.Y + 1);
			SetFollowUpText("You lose the battle taking " + damage.ToString() + " damage.");
			Global.Player.TakeDamage((ushort)damage);
		}
		
	}
	
	public void Flee()
	{
		ToggleMode(false);
		SetMainText("You attempt to flee..");
		if ((decimal)Random.value < Global.Player.FleeSuccessChange)
		{
			SetFollowUpText("You get away successfully");
		}
		else
		{
			int damage = Random.Range(fleeDamage.X, fleeDamage.Y + 1);
			SetFollowUpText("You get away, but take " + damage + " damage in the process");
			Global.Player.TakeDamage((ushort)damage);
		}
		
	}
	
	
	
	public void Close()
	{
		UI.SetEncounterWindowVis(false);
		UI.SetTradeMessageVis(false);
	}
}
