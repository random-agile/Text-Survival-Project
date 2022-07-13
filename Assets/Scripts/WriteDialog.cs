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
	
	void Awake()
	{
		uiText.text = null;
		originalText = uiText.text;
		//StartCoroutine(ShowText());
    }
    
	void Update()
	{		
		if(isTextEvent)
		{
			originalText = eventExt[0];
			StartCoroutine(ShowText());
		}
		
		if(Input.GetKeyUp(enter) && isTextEvent)
		{
			
		}
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
	
	void EventAbstract()
	{
		foreach(var x in eventExt)
		{
			
		}
	}
	
	
	
	void Next()
	{
		AbstractNext();
		originalText = "Should I run ? Should i attack them ? Should i negotiate ???";
		uiText.text = null;
		textState++;
		StartCoroutine(ShowText());
	}
	
	void NextFive()
	{
		endBox.SetActive(false);
		itemBox.SetActive(false);
	}
	
	void AbstractNext()
	{
		endBox.SetActive(false);
		audioSrc.clip = turningPage;
		audioSrc.Play();
	}
}
