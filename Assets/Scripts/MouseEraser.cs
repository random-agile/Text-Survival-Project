using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseEraser : MonoBehaviour
{
	public Texture2D gommeTex;
	public Texture2D mainTex;
	public bool isGommed;
	public TextInputManager TIM;
	public TextMeshProUGUI countText;
	public TMP_InputField inputField;
	int eraseCount = 10;
	public GameObject eraseButton;
	public AudioSource aS;
	public AudioClip aC;
	public AudioClip aD;
	public bool countLock;
	
	int xspot;
	int yspot;
	Vector2 hotSpot;
	
	void Start()
	{
		int xspot = gommeTex.width/2;
		int yspot = gommeTex.height/2;
		Vector2 hotSpot = new Vector2(xspot,yspot);
		countText.text = eraseCount.ToString();
	}
	
	public void GetEraser()
	{
		
		if(!isGommed && eraseCount > 0)
		{
			aS.clip = aC;
			aS.Play();
			Cursor.SetCursor(gommeTex, hotSpot, CursorMode.Auto);
			isGommed = true;
			countLock = true;
		}
		else if(isGommed)
		{
			Cursor.SetCursor(mainTex, hotSpot, CursorMode.Auto);
			isGommed = false;
			countLock = false;
		}
	}
	
	public void EraseText()
	{
		if(TIM.isFinished && eraseCount > 0 && isGommed)
		{
			eraseCount--;
			countText.text = eraseCount.ToString();
			TIM.theText = "";
			inputField.text = "";
			inputField.interactable = true;
			TIM.isWriting = false;
			TIM.isFinished = false;
			Cursor.SetCursor(mainTex, hotSpot, CursorMode.Auto);
			isGommed = false;
			eraseButton.SetActive(false);
			aS.clip = aD;
			TIM.textMesh.color = Color.black;
			aS.Play();
		}
	}
}
