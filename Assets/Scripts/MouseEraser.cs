using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseEraser : MonoBehaviour
{
	public Texture2D gommeTex;
	public Texture2D mainTex;
	private bool isGommed;
	public TextInputManager TIM;
	public TextMeshProUGUI countText;
	public TMP_InputField inputField;
	int eraseCount = 1;
	public GameObject eraseButton;
	public AudioSource aS;
	public AudioClip aC;
	public AudioClip aD;
	public bool countLock;
	
	void Start()
	{
		countText.text = eraseCount.ToString();
	}
	
	public void GetEraser()
	{
		
		if(!isGommed && eraseCount > 0)
		{
			aS.clip = aC;
			aS.Play();
			Cursor.SetCursor(gommeTex, Vector2.zero, CursorMode.Auto);
			isGommed = true;
			countLock = true;
		}
		else if(isGommed)
		{
			Cursor.SetCursor(mainTex, Vector2.zero, CursorMode.Auto);
			isGommed = false;
			countLock = false;
		}
	}
	
	public void EraseText()
	{
		if(TIM.isFinished && eraseCount > 0)
		{
			eraseCount--;
			countText.text = eraseCount.ToString();
			TIM.theText = "";
			inputField.text = "";
			inputField.interactable = true;
			TIM.isWriting = false;
			TIM.isFinished = false;
			Cursor.SetCursor(mainTex, Vector2.zero, CursorMode.Auto);
			isGommed = false;
			eraseButton.SetActive(false);
			aS.clip = aD;
			aS.Play();
		}
	}
}
