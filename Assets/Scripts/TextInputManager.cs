using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class TextInputManager : MonoBehaviour
{
	public TMP_InputField inputField;
	public string theText;
	public GameObject select;
	public TextMeshProUGUI textMesh;
	public bool isWriting;
	public AudioSource aS;
	public int randomus;
	public List <AudioClip> aC;
	public int writeCount;
	public TextMeshProUGUI countText;
	public bool isFinished;
	public string lastWord;
	public bool isFirst;
	
	public MMFeedbacks checkFeed;
	public MMFeedbacks countFeed;
	
	void Start()
	{
		countText.text = writeCount.ToString();
	}	
	
	void OnMouseOver()
	{
		if(isFinished)
		{
			select.SetActive(false);
		}
		else if(!isWriting)
		{
			select.SetActive(true);
		}				
	}
	
	public void DisableHighlight()
	{
		aS.clip = aC[6];
		aS.Play();
		isWriting = true;
		select.SetActive(false);
	}
	
	public void EnableHighlight()
	{
		isWriting = false;
	}
	
	void OnMouseExit()
	{
		select.SetActive(false);
	}
    
	public void CheckTextInput()
	{
		theText = inputField.text;
		inputField.interactable = false;
		isWriting = true;
		isFinished = true;
		
		if(theText == "Disgaea Horny")
		{
			textMesh.color = Color.blue;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
		}
		
		if(theText == "lighter")
		{
			textMesh.color = Color.red;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
		}
		
		if(theText.Length == 0)
		{
			inputField.interactable = true;
			isWriting = false;
			isFinished = false;
		}
	}
	
	public void ScribbleSound()
	{
		theText = inputField.text;
		isFirst = false;
		if(theText.Length > 0)
		{
			lastWord = theText.Substring(theText.Length - 1);
		}
		if(lastWord == " ")
		{
			isFirst = true;
		}
		else
		{
			writeCount --;
			countFeed.PlayFeedbacks();
		}
		
		countText.text = writeCount.ToString();
		
		randomus = Random.Range(1,6);
		
		if(randomus == 1 && !isFirst)
		{
			aS.clip = aC[0];
			aS.Play();
		}
		else if(randomus == 2 && !isFirst)
		{
			aS.clip = aC[1];
			aS.Play();
		}
		else if(randomus == 3 && !isFirst)
		{
			aS.clip = aC[2];
			aS.Play();
		}
		else if(randomus == 4 && !isFirst)
		{
			aS.clip = aC[3];
			aS.Play();
		}
		else if(randomus == 5 && !isFirst)
		{
			aS.clip = aC[4];
			aS.Play();
		}
	}
 
	void DisableKey( KeyCode key )
	{
		if( Event.current.keyCode == key)
		{
			if( Event.current.type == EventType.KeyUp || Event.current.type == EventType.KeyDown )
			{
				Event.current.Use();
			}
		}
	}
 
	void OnGUI()
	{
		DisableKey( KeyCode.Backspace );
	}
	
}
