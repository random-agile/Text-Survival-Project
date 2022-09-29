using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriteDialog : MonoBehaviour
{
	public AudioSource audioSrc;
	public AudioClip turningPage;
	public GameObject itemBox;
	public GameObject endBox;
	public KeyCode enter = KeyCode.Return;
	public string originalText;
	public TMP_Text uiText;
	int textState;
	
	public List <string> eventExt;
	public List <string> nothingExt;
	public bool isTextEvent;
	public bool isNothing;
	int loopControl =1;
	bool updateSecurity;
	
	public List <GameObject> menu;
	
	public GameObject eventOne;
	
	EventsSystem ES;
	
	void Awake()
	{
		uiText.text = null;
		originalText = uiText.text;
		ES = GameObject.Find("Player").GetComponent<EventsSystem>();
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
				eventOne.SetActive(false);
				ES.isEvent = 0;
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
		audioSrc.clip = turningPage;
		audioSrc.Play();
		foreach (var obj in menu)
		{
			obj.SetActive(false);
		}
	}
		
	void AbstractNext()
	{
		endBox.SetActive(false);
		audioSrc.clip = turningPage;
		audioSrc.Play();
		uiText.text = null;
	}
	
	void AbstractNextFollow()
	{
		uiText.text = null;
		loopControl++;
	}
	
	void AbstractEnd()
	{
		endBox.SetActive(false);
		itemBox.SetActive(false);
		updateSecurity = false;
		loopControl = 1;
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
			yield return new WaitForSeconds(0.005f);			
		}
		endBox.SetActive(true);
	}	

}
