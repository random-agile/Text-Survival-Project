using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsSystem : MonoBehaviour
{
	WriteDialog WD;
	ItemsSystem IS;

	[Header("Event Variables")]
	public string eventId;
	public string eventName;
	
	[Header("Text Variables")]
	string text;	
	GameObject dialogBox;
	string colorWord;

	[Header("Door Variables")]
	public List<Animator> anims;
	public List<bool> isOpen;
	string doorNumber;
	int door;

	void Awake() //Get All Necessary Components
	{
		eventId = "0";
		dialogBox = GameObject.Find("DialogBox");
		WD = GameObject.Find("DialogBox/Text").GetComponent<WriteDialog>();
		IS = this.gameObject.GetComponent<ItemsSystem>();
		dialogBox.SetActive(false);
	}
	
	private void OnTriggerEnter(Collider other) // Check event id when colliding with the event
	{
		WD.actualEvent = other.gameObject;
		if(other.transform.tag == "Interactible")
		{
			eventName = other.gameObject.name;
			eventId = other.gameObject.name.Substring(other.gameObject.name.Length - 2);
		}		
	}
	
	private void OnTriggerExit(Collider other) // Reset event id to 0 when not colliding with event
	{
		eventId = "0";
		WD.actualEvent = null;
	}

	public void Search() //If eye button is pressed, will trigger the event according to his id
	{
		switch (eventId)
		{
		case "0":
				text = "There's nothing interesting here.";
				WD.nothingExt.Add(text);
				text = null;
				WD.isNothing = true;
				dialogBox.SetActive(true);
				break;
			
		case " 1":
				WD.isColor = true;
				text = "There is a piece of paper at my feet, but it is blank...";
				AbstractAdd();
				text = "I don't know what to do with it, maybe I should keep it just in case.";
				AbstractAdd();
				text = "I could also write stuff on it... After all considering the situation i'm in right now, It could be a way to stay sane...";
				AbstractAdd();
				text = "Obtained a <color=red>small paper</color>.";
				AbstractEnd();
				break;
				
		case " 2":
				Debug.Log("ok");
				break;
				
		case " 3":
				WD.isColor = true;
				text = "A blue key, seems important.";
				AbstractAdd();
				text = "Obtained a <color=blue>blue key</color>.";
				AbstractEndItem();
				break;

		case " 4":
				CheckDoor();
				break;
		}
	}
	
	void CheckDoor() // Open and close doors depending on their current state
	{
		doorNumber = eventId.Substring(eventId.Length - 1);
		door = Convert.ToInt32(doorNumber);

		if (!isOpen[door])
		{
			anims[door].SetBool("isOpened", true);
			isOpen[door] = true;
		}
		else if (isOpen[door])
		{
			anims[door].SetBool("isOpened", false);
			isOpen[door] = false;
		}
	}

	// Different functions below for abstracting some lines of code
	void AbstractAdd() // use this between each line of dialogue
	{
		WD.eventExt.Add(text);
		text = null;
	}

	void AbstractEnd() // use this to finish event
    {
		WD.eventExt.Add(text);
		text = null;
		WD.isTextEvent = true;
		dialogBox.SetActive(true);
    }

	void AbstractEndItem() // use this to finish event with a new item obtained
	{
		WD.eventExt.Add(text);
		text = null;
		WD.isTextEvent = true;
		dialogBox.SetActive(true);
		IS.CheckPlace();
	    IS.AddItem(eventName);
	}
}
