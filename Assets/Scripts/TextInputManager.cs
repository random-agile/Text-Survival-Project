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
	
	public MMFeedbacks feedBack;
	
	void Start()
	{
		countText.text = writeCount.ToString();
	}	
	
	void OnMouseOver()
	{
		if(!isWriting)
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
		
		if(theText == "DisgaeaHorny")
		{
			textMesh.color = Color.blue;
			aS.clip = aC[5];
			aS.Play();
			feedBack?.PlayFeedbacks();
		}
		
		if(theText == "lighter")
		{
			textMesh.color = Color.red;
			aS.clip = aC[5];
			aS.Play();
			feedBack?.PlayFeedbacks();
		}
		
		inputField.interactable = false;
		isWriting = true;
		//writeCount -= theText.Length;
		//countText.text = writeCount.ToString();
		
		if(theText.Length == 0)
		{
			inputField.interactable = true;
			isWriting = false;
		}
	}
	
	public void ScribbleSound()
	{
		theText = inputField.text;
		writeCount --;
		countText.text = writeCount.ToString();
		
		randomus = Random.Range(1,6);
		if(randomus == 1)
		{
			aS.clip = aC[0];
			aS.Play();
		}
		else if(randomus == 2)
		{
			aS.clip = aC[1];
			aS.Play();
		}
		else if(randomus == 3)
		{
			aS.clip = aC[2];
			aS.Play();
		}
		else if(randomus == 4)
		{
			aS.clip = aC[3];
			aS.Play();
		}
		else if(randomus == 5)
		{
			aS.clip = aC[4];
			aS.Play();
		}	
	}
	
}
