using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AdventurerGroup
{
	private string name;
	private string fightText;
	private string tradeText;
	private Store store;
	private decimal combatProficiency;	
	public AdventurerGroup (string name, string fightText, string tradeText, Store store, decimal combatProficiency)
	{
		this.name = name;
		this.fightText = fightText;
		this.tradeText = tradeText;
		this.store = store;
		this.combatProficiency = combatProficiency;
	}
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	public string FightText
	{
		get
		{
			return this.fightText;
		}
	}

	public string TradeText
	{
		get
		{
			return this.tradeText;
		}
	}

	public Store Store
	{
		get
		{
			return this.store;
		}
	}

	public decimal  CombatProficiency
	{
		get
		{
			return this.combatProficiency;
		}
	}
	public override string ToString ()
	{
		return string.Format ("[AdventurerGroup: name={0}, fightText={1}, tradeText={2}]", name, fightText, tradeText);
	}
	
}
