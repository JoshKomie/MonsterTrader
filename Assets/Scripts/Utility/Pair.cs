using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Pair 
{
	private int x;
	private int y;
	public Pair (int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	public Pair (float x, float y)
	{
		this.x = (int)x;
		this.y = (int)y;
	}
	public  int X
	{
		get
		{
			return this.x;
		}
	}

	public int Y
	{
		get
		{
			return this.y;
		}
	}
	public override string ToString ()
	{
		return string.Format ("[Pair: x={0}, y={1}]", x, y);
	}
	
	public override bool Equals (object obj)
	{
		if (obj == null)
			return false;
		if (ReferenceEquals (this, obj))
			return true;
		if (obj.GetType () != typeof(Pair))
			return false;
		Pair other = (Pair)obj;
		return x == other.x && y == other.y;
	}
	

	public override int GetHashCode ()
	{
		unchecked {
			return x.GetHashCode () ^ y.GetHashCode ();
		}
	}
	
	
}
