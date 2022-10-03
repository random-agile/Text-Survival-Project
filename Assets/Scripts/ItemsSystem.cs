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
	int itemUsed;
	public List <bool> isPlace;
	public List <string> itemName;
	
	public void AddItem(string item)
	{
		switch(item)
		{
		case "Allumette":
			newItem = itemsContainer[1];			
			itemsMenu[itemsNb].sprite = newItem;
			itemsMenu[itemsNb].GetComponent<Image>().SetNativeSize();
			itemName[itemsNb] = "Allumette";
			break;
		case "BlueKey":
			newItem = itemsContainer[2];			
			itemsMenu[itemsNb].sprite = newItem;
			itemsMenu[itemsNb].GetComponent<Image>().SetNativeSize();
			itemName[itemsNb] = "BlueKey";
			break;
		}
	}
	
	void UseItem()
	{
		switch(itemName[itemUsed])
		{
		case "Allumette":
			Debug.Log("alum");
			break;
		case "BlueKey":
			Debug.Log("blue");
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
			
			if(isPlace.TrueForAll(x => x))
			{
				Debug.Log("c'est plein");
			}			
		}
	}
	
	public void ItemOneUse()
	{	
		itemUsed = 0;
		itemsMenu[0].sprite = itemsContainer[0];
		UseItem();
		itemName[0] = null;
	}
	
	public void ItemTwoUse()
	{	
		itemUsed = 1;
		itemsMenu[1].sprite = itemsContainer[0];
		UseItem();
		itemName[1] = null;
	}
	
	public void ItemThreeUse()
	{	
		itemUsed = 2;
		itemsMenu[1].sprite = itemsContainer[0];
		UseItem();
		itemName[2] = null;
	}
	
	public void ItemFourUse()
	{	
		itemUsed = 3;
		itemsMenu[1].sprite = itemsContainer[0];
		UseItem();
		itemName[3] = null;
	}
	
	public void ItemFiveUse()
	{	
		itemUsed = 4;
		itemsMenu[0].sprite = itemsContainer[0];
		UseItem();
		itemName[4] = null;
	}
	
	public void ItemSixUse()
	{	
		itemUsed = 5;
		itemsMenu[1].sprite = itemsContainer[0];
		UseItem();
		itemName[5] = null;
	}
	
	public void ItemSevenUse()
	{	
		itemUsed = 6;
		itemsMenu[1].sprite = itemsContainer[0];
		UseItem();
		itemName[6] = null;
	}
	
	public void ItemEightUse()
	{	
		itemUsed = 7;
		itemsMenu[1].sprite = itemsContainer[0];
		UseItem();
		itemName[7] = null;
	}
	
}

