using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsSystem : MonoBehaviour
{
	public int isEvent;
	string text;
	WriteDialog WD;
	ItemsSystem IS;
	public GameObject dialogBox;
	string itemName;
	
	void Awake()
	{
		dialogBox.SetActive(true);
		WD = GameObject.Find("DialogBox/Text").GetComponent<WriteDialog>();
		IS = this.gameObject.GetComponent<ItemsSystem>();
		dialogBox.SetActive(false);
	}
	
	private void OnTriggerEnter(Collider other)
	{
		WD.actualEvent = other.gameObject;
		
		if(other.gameObject.name == "Note 1")
		{
			isEvent = 1;
		}
		else if(other.gameObject.name == "Allumette")
		{
			isEvent = 2;
		}
		else if(other.gameObject.name == "BlueKey")
		{
			isEvent = 3;
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		isEvent = 0;
		WD.actualEvent = null;			
	}
	
	public void Search()
	{
		
		if(isEvent > 0)
		{
			if(isEvent == 1)
			{
				text = "There is a piece of paper at my feet, but it is blank...";
				AbstractAdd();
				text = "I don't know what to do with it, maybe I should keep it just in case.";
				AbstractAdd();
				text = "I could also write stuff on it... After all considering the situation i'm in right now, It could be a way to stay sane...";
				AbstractAdd();
				text = "Obtained a <color=red>small paper</color>.";
				AbstractEnd();
			}
			
			else if(isEvent == 2)
			{
				text = "A matchstick box, always useful.";
				AbstractAdd();
				text = "Obtained a <color=red>matchstick box</color>.";
				AbstractEnd();
				itemName = "Allumette";
				IS.CheckPlace();
				IS.AddItem(itemName);
			}
			
			else if(isEvent == 3)
			{
				text = "A blue key, seems important.";
				AbstractAdd();
				text = "Obtained a <color=blue>blue key</color>.";
				AbstractEnd();
				itemName = "BlueKey";
				IS.CheckPlace();
				IS.AddItem(itemName);
			}
		}
		
		if(isEvent == 0)
		{
			text = "There's nothing interesting here.";
			WD.nothingExt.Add(text);
			text = null;
			WD.isNothing = true;
			dialogBox.SetActive(true);
		}
	}
	
	void AbstractAdd()
	{
		WD.eventExt.Add(text);
		text = null;
	}

	void AbstractEnd()
    {
		WD.eventExt.Add(text);
		text = null;
		WD.isTextEvent = true;
		dialogBox.SetActive(true);
	}
}
