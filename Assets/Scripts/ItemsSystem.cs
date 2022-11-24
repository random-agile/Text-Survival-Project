using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsSystem : MonoBehaviour
{
	[Header("Items Infos and Lists")]
	public Sprite newItem;
	public List <Sprite> itemsContainer;
	public List <Image> itemsMenu;	
	public List <bool> isPlace;
	public List <string> itemName;
	int itemsNb;
	int itemUsed;
	string itemStock;

	public void AddItem(string item) // Add Item to the inventory depending on name
	{
		itemStock = item;

		switch(item)
		{
		case "Allumette 1":
			newItem = itemsContainer[1];
			AddItemAbstract();
			break;
		case "BlueKey 3":
			newItem = itemsContainer[2];
			AddItemAbstract();
			break;
		}
	}
	
	void UseItem() // Use item in menu
	{
		switch(itemName[itemUsed])
		{
		case "Allumette 1":
			Debug.Log("alum");
			break;
		case "BlueKey 3":
			Debug.Log("blue");
			break;
		}
	}
		
	public void CheckPlace() // Check where the next item will be stored and tell if the maximum capacity as been reached
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
	public void ItemOneUse() // public function to use when pressing the corresponding button
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

	// Different functions below for abstracting some lines of code
	void AddItemAbstract()
	{
		itemsMenu[itemsNb].sprite = newItem;
		itemsMenu[itemsNb].GetComponent<Image>().SetNativeSize();
		itemName[itemsNb] = itemStock;
	}

}

