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
	
	public void AddItem(string item)
	{
		switch(item)
		{
		case "Allumette":
			newItem = itemsContainer[0];			
			itemsMenu[itemsNb].sprite = newItem;
			itemsMenu[itemsNb].GetComponent<Image>().SetNativeSize();
			itemsNb++;
			break;
		case "BlueKey":
			newItem = itemsContainer[1];			
			itemsMenu[itemsNb].sprite = newItem;
			itemsMenu[itemsNb].GetComponent<Image>().SetNativeSize();
			itemsNb++;
			break;
		}
	}
}

