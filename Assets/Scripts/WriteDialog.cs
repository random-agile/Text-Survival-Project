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
	//public double delay = 0.02f;
	
	void Awake()
	{
		originalText = uiText.text;
		uiText.text = null;
	    StartCoroutine(ShowText());
    }
    
	void Update()
	{
		
		if(Input.GetKeyUp(enter)) 
			if(textState == 0) Next();
			else if(textState == 1) NextTwo();
			else if(textState == 2) NextThree();
			else if(textState == 3) NextFour();
			else if(textState == 4) NextFive();
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
	
	void Next()
	{
		AbstractNext();
		originalText = "Should I run ? Should i attack them ? Should i negotiate ???";
		uiText.text = null;
		textState++;
		StartCoroutine(ShowText());
	}
	
	void NextTwo()
	{
		AbstractNext();
		originalText = "Ton grand père est partit se faire des implantations de cheveux en turquie.";
		uiText.text = null;
		textState++;
		StartCoroutine(ShowText());
	}
	
	void NextThree()
	{
		AbstractNext();
		originalText = "Je l'ai le pass sanitaire, voilà, la serveuse est venue puis ma scanner le qr code et le tour joué, moi j'dis allons y quoi.";
		uiText.text = null;
		textState++;
		StartCoroutine(ShowText());
	}
	
	void NextFour()
	{
		AbstractNext();
		originalText = "I have the vaccine card, there you go, the waiter scanned it and that's it !";
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
