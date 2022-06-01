using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
	
	
	void OnMouseOver()
	{
		if(!isWriting)
		{
			select.SetActive(true);
		}		
	}
	
	public void DisableHighlight()
	{
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
		
		if(theText == "Islamoboucled")
		{
			textMesh.color = Color.blue;
			Debug.Log("ça marche");
			aS.clip = aC[5];
			aS.Play();
			inputField.interactable = false;
			isWriting = true;
		}
	}
	
	public void ScribbleSound()
	{
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
