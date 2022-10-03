using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsSystem : MonoBehaviour
{
	public List <Sprite> itemsContainer;
	public List <Image> itemsMenu;
	public Sprite newItem;
	int itemsNb;
	public List <bool> isPlace;
	public List <string> itemName;
	
	public void AddItem(string item)
	{
		switch(item)
		{
		case "Allumette":
			newItem = itemsContainer[0];			
			itemsMenu[itemsNb].sprite = newItem;
			itemsMenu[itemsNb].GetComponent<Image>().SetNativeSize();
			itemName[itemsNb] = "Allumette";
			break;
		case "BlueKey":
			newItem = itemsContainer[1];			
			itemsMenu[itemsNb].sprite = newItem;
			itemsMenu[itemsNb].GetComponent<Image>().SetNativeSize();
			itemName[itemsNb] = "BlueKey";
			break;
		}
	}
	
	public void CheckPlace()
	{
		for(int i = 0; i < 8; i++)
		{
			if(isPlace[i])
			{
				Debug.Log(isPlace[i]);
			}
			else if(!isPlace[i])
			{
				isPlace[i] = true;
				itemsNb = i;
				return;
			}
			else
			{
				Debug.Log("c'est plein");
			}
		}
	}
}

