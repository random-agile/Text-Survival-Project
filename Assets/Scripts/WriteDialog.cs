using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WriteDialog : MonoBehaviour
{
	//public AudioSource audioSrc;
	public AudioClip turningPage;
	public AudioClip doorLocked;
	public AudioClip mystery;
	public GameObject itemBox;
	public GameObject endBox;
	public KeyCode enter = KeyCode.Return;
	public string originalText;
	public TMP_Text uiText;
	
	public List <string> eventExt;
	public List <string> nothingExt;
	public bool isTextEvent;
	public bool isNothing;
	public bool isColor;
	int loopControl =1;
	bool updateSecurity;
	
	public List <GameObject> menu;
	public GameObject actualEvent;	
	
	EventsSystem ES;
	PlayerController PC;
	
	public float displaySpeed;
	
	void Awake()
	{
		uiText.text = null;
		originalText = uiText.text;
		ES = GameObject.Find("Player").GetComponent<EventsSystem>();
		PC = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
	void Update()
	{				
		if(isTextEvent && !updateSecurity)
		{
			AbstractStart();
			originalText = eventExt[loopControl -1];
			StartCoroutine(ShowText());
		}
		
		if(Input.GetKeyUp(enter) && isTextEvent)
		{
			if(loopControl > eventExt.Count -1)
			{
				AbstractEnd();				
				isTextEvent = false;
				eventExt.Clear();
				actualEvent.SetActive(false);
				ES.eventId = "0";
			}
			
			if(loopControl == eventExt.Count -1 && isColor)
			{
				AbstractNext();
				originalText = eventExt[loopControl];
				AbstractNextFollow();
				ShowColorText();
				//audioSrc.clip = mystery;
				//audioSrc.Play();
			}
			
			if(loopControl <= eventExt.Count -1)
			{
				AbstractNext();
				originalText = eventExt[loopControl];
				AbstractNextFollow();
				StartCoroutine(ShowText());				
			}
		}
		
		if(isNothing && !updateSecurity)
		{
			AbstractStart();
			originalText = nothingExt[loopControl -1];
			StartCoroutine(ShowText());
		}
		
		if(Input.GetKeyUp(enter) && isNothing)
		{
			AbstractEnd();
			nothingExt.Clear();
			isNothing = false;
		}
	}
	
	void AbstractStart()
	{
		updateSecurity = true;
		if(!ES.isDoor)
		{
			//audioSrc.clip = turningPage;
			//audioSrc.Play();
		}
		else
		{
			//audioSrc.clip = doorLocked;
			//audioSrc.Play();
		}
		
		foreach (var obj in menu)
		{
			obj.SetActive(false);
		}
	}
		
	void AbstractNext()
	{
		endBox.SetActive(false);
		uiText.text = null;
	}

	
	void AbstractNextFollow()
	{
		uiText.text = null;
		loopControl++;
		//audioSrc.clip = turningPage;
		//audioSrc.Play();
	}
	
	void AbstractEnd()
	{
		uiText.text = null;
		isColor = false;
		endBox.SetActive(false);
		itemBox.SetActive(false);
		updateSecurity = false;
		loopControl = 1;
		ES.isDoor = false;
		PC.isInteraction = false;
		//audioSrc.clip = turningPage;
		foreach (var obj in menu)
		{
			obj.SetActive(true);
		}		
	}

	IEnumerator ShowText()
	{
		for (int i =0; i <= originalText.Length; i++)
		{
			uiText.text = originalText.Substring(0,i);
			yield return new WaitForSeconds(displaySpeed);		
		}
		endBox.SetActive(true);
	}	
	
	void ShowColorText()
	{
		uiText.text = originalText;
		endBox.SetActive(true);
	}
}
