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
	public bool isTextEvent;
	int loopControl =1;
	bool updateSecurity;
	
	public GameObject searchBox;
	public GameObject menuBox;
	
	EventSystem ES;
	
	void Awake()
	{
		uiText.text = null;
		originalText = uiText.text;
		ES = GameObject.Find("Player").GetComponent<EventSystem>();
    }
    
	void Update()
	{		
		Debug.Log(loopControl);
		Debug.Log(eventExt.Count -1);
		
		if(isTextEvent && !updateSecurity)
		{
			audioSrc.clip = turningPage;
			audioSrc.Play();
			searchBox.SetActive(false);
			menuBox.SetActive(false);
			originalText = eventExt[loopControl -1];
			StartCoroutine(ShowText());
			updateSecurity = true;
		}
		
		if(Input.GetKeyUp(enter) && isTextEvent)
		{
			if(loopControl > eventExt.Count -1)
			{
				endBox.SetActive(false);
				itemBox.SetActive(false);
				isTextEvent = false;
				loopControl = 1;
				searchBox.SetActive(true);
				menuBox.SetActive(true);
				eventExt.Clear();
				updateSecurity = false;
				ES.isCheckedOne = true;
			}
			
			if(loopControl <= eventExt.Count -1)
			{
				AbstractNext();
				originalText = eventExt[loopControl];
				uiText.text = null;
				loopControl++;
				StartCoroutine(ShowText());
			}
		}
	}	
		
	void AbstractNext()
	{
		endBox.SetActive(false);
		audioSrc.clip = turningPage;
		audioSrc.Play();
		uiText.text = null;
	}

	IEnumerator ShowText()
	{
		for (int i =0; i <= originalText.Length; i++)
		{
			uiText.text = originalText.Substring(0,i);
			yield return new WaitForSeconds(0.02f);			
		}
		endBox.SetActive(true);
	}	

}
