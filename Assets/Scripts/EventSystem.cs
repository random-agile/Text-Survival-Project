﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
	public int isEvent;
	string text;
	WriteDialog WD;
	
	public GameObject dialogBox;
	
	void Awake()
	{
		dialogBox.SetActive(true);
		WD = GameObject.Find("DialogBox/Text").GetComponent<WriteDialog>();
		dialogBox.SetActive(false);
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Note 1")
		{
			isEvent = 1;
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
			isEvent = 0;
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
				AbstractAdd();
				WD.isTextEvent = true;
				dialogBox.SetActive(true);
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
}
