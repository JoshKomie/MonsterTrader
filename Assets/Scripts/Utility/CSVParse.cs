using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
public class CSVParse : MonoBehaviour 
{
	public static ushort[,] Parse(string csv, int rows, int columns)
	{
		int x = 0, y = 0;
		ushort[,] data = new ushort[rows, columns];
		int index = 0;
		string current = "", val;
		foreach (char c in csv)
		{
			if (c == ',' || c == ' ')
			{
				
				data[x, y] = eval (current);
				current = "";
				index++;
				y = (index - 1) / columns;
				x = (index - 1) % columns;
				if (y >= columns || x >= rows)
					break;
				
			}
			else
			{
				current += c;
				/*data[x, y] =  (ushort)Char.GetNumericValue(c);
				Debug.Log (data[x, y]);*/
				/*index++;
				y = (index - 1) / columns;
				x = (index - 1) % columns;
				if (y >= columns || x >= rows)
					break;*/
				//Debug.Log ("index: " + index + "x: " + x + "y: " + y);
			}
		}
		
		
		return data;
		
	}
	
	private static ushort eval(string s)
	{
		//Debug.Log ("parsing: " + s + "got val: " + int.Parse(s));
		return  ushort.Parse(s);
		/*Debug.Log (data[x, y]);
		index++;
		y = (index - 1) / columns;
		x = (index - 1) % columns;
		if (y >= columns || x >= rows)
			break;*/
	}
	
	
}
