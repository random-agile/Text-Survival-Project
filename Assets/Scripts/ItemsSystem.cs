using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsSystem : MonoBehaviour
{
	public List <Sprite> itemsContainer;
	public List <Image> itemsMenu;
	public Sprite newItem;

	
	public void AddItem(string item)
	{
		switch(item)
		{
		case "Allumette":
			newItem = itemsContainer[0];
			itemsMenu[0].sprite = newItem;
			itemsMenu[0].GetComponent<Image>().SetNativeSize();
		break;
		}
	}
	
	void AddInventory()
	{

	}
}
