using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum SOUNDS {SELECT, NEGATIVE, COINGET, COINLOSE, LOSEHEALTH, SWORDDRAW, SWORDFIGHT};
public class GlobalSound : MonoBehaviour 
{
	private AudioSource source;
	
	public AudioClip Select, Negative, Coinget, Coinlose, loseHealth, SwordDraw, SwordFight;
	
	public static GlobalSound instance;
	
	//public Toggle mute;
	public static bool muted = false;
	public void Start()
	{
		source = GetComponent<AudioSource>();
		instance = this;
		
	}
	public static void Play(SOUNDS sound)
	{
		if (muted)
			return;
		switch (sound)
		{
			case SOUNDS.SELECT:
				instance.source.clip = instance.Select;
				break;
		case SOUNDS.NEGATIVE:
			instance.source.clip = instance.Negative;
			break;
		
		case SOUNDS.COINGET:
			instance.source.clip = instance.Coinget;
			break;
		case SOUNDS.COINLOSE:
			instance.source.clip = instance.Coinlose;
			break;
		case SOUNDS.LOSEHEALTH:
			instance.source.clip = instance.loseHealth;
			break;
		case SOUNDS.SWORDDRAW:
			instance.source.clip = instance.SwordDraw;
			break;
		case SOUNDS.SWORDFIGHT:
			instance.source.clip = instance.SwordFight;
			break;
		}
		instance.source.Play();
	}
	
	
}
