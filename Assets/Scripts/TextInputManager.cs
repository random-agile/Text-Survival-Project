using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class TextInputManager : MonoBehaviour
{
	Inventory I;
	public MouseEraser ME;
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
	public GameObject eraseButton;
	bool isZero;
	public List<Texture2D> cursorTexture;
	public BoxCollider2D boxCol;
	
	public MMFeedbacks checkFeed;
	public MMFeedbacks countFeed;
	
	int xspot;
	int yspot;
	Vector2 hotSpot;
	
	public bool menuOpen;
	int bookWords;
	public List<TextMeshProUGUI> bookTexts;
	public List<string> foundWords;
	private KeyCode a = KeyCode.Space;
	
	public GameObject book;
	public TextMeshProUGUI countTextWord;
	
	public Button endButton;
	
	public List<TextMeshProUGUI> actionCommand;
	int commandFound;
	public List<string> foundCommands;
	
	void Awake()
	{
		//DontDestroyOnLoad(this.gameObject);
	}	
	
	void Start()
	{
		I = this.gameObject.GetComponent<Inventory>();
		int xspot = cursorTexture[0].width/2;
		int yspot = cursorTexture[0].height/2;
		Vector2 hotSpot = new Vector2(xspot,yspot);
		Cursor.SetCursor(cursorTexture[0], hotSpot, CursorMode.Auto);
		countText.text = writeCount.ToString();
	}	
	
	void Update()
	{
		if(isZero)
		{
			theText = inputField.text.Remove(inputField.text.Length -1);
			inputField.text = theText;
			isZero = false;
		}
		
		if(Input.GetKeyUp(a))
		{
			if(!menuOpen && !isWriting && !I.bagOpen)
			{
				OpenBook();
				aS.clip = aC[8];
				aS.Play();
				menuOpen = true;
			}
			else if(menuOpen && !I.bagOpen)
			{
				CloseBook();
				menuOpen = false;
				aS.clip = aC[9];
				aS.Play();
			}
		}
	}
	
	void OnMouseEnter()
	{
		if(!isWriting && !isFinished)
		{
		aS.clip = aC[7];
			aS.Play();
		}
		
		if(!isFinished)
		{
			Cursor.SetCursor(cursorTexture[2], hotSpot, CursorMode.Auto);
			ME.isGommed = false;
		}
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
		if(!ME.isGommed)
		{
			Cursor.SetCursor(cursorTexture[0], hotSpot, CursorMode.Auto);
		}
	}
    
	public void CheckTextInput()
	{
		theText = inputField.text;
		inputField.interactable = false;
		isWriting = false;
		isFinished = true;
		eraseButton.SetActive(true);
		
		if(theText == "Disgaea Horny" && !foundWords.Contains("Disgaea Horny"))
		{
			textMesh.color = Color.blue;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
			AddWord();			
		}
		
		if(theText == "lighter" && !foundWords.Contains("lighter"))
		{
			textMesh.color = Color.red;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
			AddWord();
		}
		
		if(theText == "Talk" && !foundWords.Contains("Talk"))
		{
			textMesh.color = Color.yellow;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
			AddCommand();
		}
		
		if(theText == "Look" && !foundWords.Contains("Look"))
		{
			textMesh.color = Color.yellow;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
			AddCommand();
		}
		
		if(theText == "Smell" && !foundWords.Contains("Smell"))
		{
			textMesh.color = Color.yellow;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
			AddCommand();
		}
		
		if(theText == "Listen" && !foundWords.Contains("Listen"))
		{
			textMesh.color = Color.yellow;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
			AddCommand();
		}
		
		if(theText == "Touch" && !foundWords.Contains("Touch"))
		{
			textMesh.color = Color.yellow;
			aS.clip = aC[5];
			aS.Play();
			checkFeed.PlayFeedbacks();
			AddCommand();
		}
		
		if(theText.Length == 0)
		{
			inputField.interactable = true;
			isWriting = false;
			isFinished = false;
			eraseButton.SetActive(false);
		}
		
		endButton.Select();
	}
	
	public void ScribbleSound()
	{
		theText = inputField.text;
		isFirst = false;
		
		if(writeCount == 0)
		{
			isZero = true;
		}
		
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
			if(ME.countLock)
			{
				ME.countLock = false;
			}
			else if(writeCount > 0)
			{
				playSound();
				writeCount --;
				countFeed.PlayFeedbacks();
			}
		}
		
		countText.text = writeCount.ToString();
		
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
	
	void playSound()
	{
		randomus = Random.Range(1,6);
		
		if(randomus == 1 && !isFirst && writeCount > 0)
		{
			aS.clip = aC[0];
			aS.Play();
		}
		else if(randomus == 2 && !isFirst && writeCount > 0)
		{
			aS.clip = aC[1];
			aS.Play();
		}
		else if(randomus == 3 && !isFirst && writeCount > 0)
		{
			aS.clip = aC[2];
			aS.Play();
		}
		else if(randomus == 4 && !isFirst && writeCount > 0)
		{
			aS.clip = aC[3];
			aS.Play();
		}
		else if(randomus == 5 && !isFirst && writeCount > 0)
		{
			aS.clip = aC[4];
			aS.Play();
		}
	}
	
	void OpenBook()
	{
		book.SetActive(true);
		boxCol.enabled = false;
	}
	
	void CloseBook()
	{
		book.SetActive(false);
		boxCol.enabled = true;
		
	}
	
	public void ButtonBook()
	{
		if(!menuOpen && !isWriting && !I.bagOpen)
			{
				OpenBook();
				aS.clip = aC[8];
				aS.Play();
				menuOpen = true;
			}
		else if(menuOpen && !I.bagOpen)
			{
				CloseBook();
				menuOpen = false;
			aS.clip = aC[9];
				aS.Play();
			}
	}
	
	void AddWord()
	{
		bookTexts[bookWords].text = theText;
		bookTexts[bookWords].color = textMesh.color;
		bookWords++;
		countTextWord.text = bookWords.ToString();
		foundWords.Add(theText);
	}
	
	void AddCommand()
	{
		actionCommand[commandFound].text = theText;
		actionCommand[commandFound].color = textMesh.color;
		commandFound++;
		foundCommands.Add(theText);
	}
	
}
