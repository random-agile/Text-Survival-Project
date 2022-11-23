using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsSystem : MonoBehaviour
{
	WriteDialog WD;
	ItemsSystem IS;

	[Header("Event Variables")]
	public int isEvent;
	public string eventName;
	string text;	
	GameObject dialogBox;

	[Header("Door Variables")]
	public List<Animator> anims;
	public List<bool> isOpen;
	string doorNumber;
	int door;

	void Awake() //Get All Necessary Components
	{
		dialogBox = GameObject.Find("DialogBox");
		//dialogBox.SetActive(true);
		WD = GameObject.Find("DialogBox/Text").GetComponent<WriteDialog>();
		IS = this.gameObject.GetComponent<ItemsSystem>();
		dialogBox.SetActive(false);
	}
	
	private void OnTriggerEnter(Collider other) // Check event id when colliding with the event
	{
		WD.actualEvent = other.gameObject;
		eventName = other.gameObject.name;
		switch (eventName)
        {
			case "Note 1":
				isEvent = 1;
				break;

			case "Allumette":
				isEvent = 2;
				this.GetComponent<SphereCollider>().enabled = false;
				break;

			case "BlueKey":
				isEvent = 3;
				break;

			case "Porte 1":
				isEvent = 4;
				break;
		}	
	}
	
	private void OnTriggerExit(Collider other) // Reset event id to 0 when not colliding with event
	{
		isEvent = 0;
		WD.actualEvent = null;
		this.GetComponent<SphereCollider>().enabled = true;
	}

	public void Search() //If eye button is pressed, will trigger the event according to his id
	{
		switch (isEvent)
		{
			case 0:
				text = "There's nothing interesting here.";
				WD.nothingExt.Add(text);
				text = null;
				WD.isNothing = true;
				dialogBox.SetActive(true);
				break;

			case 1:
				text = "There is a piece of paper at my feet, but it is blank...";
				AbstractAdd();
				text = "I don't know what to do with it, maybe I should keep it just in case.";
				AbstractAdd();
				text = "I could also write stuff on it... After all considering the situation i'm in right now, It could be a way to stay sane...";
				AbstractAdd();
				text = "Obtained a <color=red>small paper</color>.";
				AbstractEnd();
				break;

			case 2:
				text = "A blue key, seems important.";
				AbstractAdd();
				text = "Obtained a <color=blue>blue key</color>.";
				AbstractEndItem();
				break;

			case 3:
				Debug.Log("ok");
				break;

			case 4:
				CheckDoor();
				break;
		}
	}
	void CheckDoor() // Open and close doors depending on their current state
	{
		doorNumber = eventName.Substring(eventName.Length - 1);
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

	void AbstractEndItem()
    {
		WD.eventExt.Add(text);
		text = null;
		WD.isTextEvent = true;
		dialogBox.SetActive(true);
		IS.CheckPlace();
		IS.AddItem(eventName);
	}
}
