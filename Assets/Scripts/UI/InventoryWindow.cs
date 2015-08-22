using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWindow : MonoBehaviour 
{
	public GameObject ItemPanel;
	private GameObject itemPanel;
	private int itemInterfaceOffset = 0;
	private int itemInterfaceDistance = 25;

	private List<GameObject> currentInterfaces;
	public void Close()
	{
		UI.SetInventoryWindowVis(false);
	}
	
	
	
	public void Init(List<Item> items)
	{
		//Debug.Log (items.Count);
		itemPanel = GameObject.Find("Items");
		ushort index=  0;
		
		if (currentInterfaces == null)
			currentInterfaces = new List<GameObject>();
		else
		{
			foreach (GameObject g in currentInterfaces)
			{
				Destroy(g);
			}
			currentInterfaces.Clear();
			itemInterfaceOffset = 0;
		}
			
		foreach (Item i in items)
		{
			GameObject itemInterface = Instantiate(ItemPanel) as GameObject;
			itemInterface.transform.position = new Vector2(itemInterface.transform.position.x , itemInterface.transform.position.y- itemInterfaceOffset);
			itemInterfaceOffset += itemInterfaceDistance;
			itemInterface.transform.SetParent(itemPanel.transform, false);
			itemInterface.GetComponent<InventoryItem>().Init(i);
			index++;
			currentInterfaces.Add(itemInterface);
		}
		
	}
	
	
}
