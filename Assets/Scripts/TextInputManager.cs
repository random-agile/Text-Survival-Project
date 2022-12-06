using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;
using System.IO;
using System.Collections;

public class TextInputManager : MonoBehaviour
{
	[Header("Scripts")]
	Inventory I;
	SoundEvent SE;

	[Header("Text Related")]
	public TMP_InputField inputField;
	public string theText;
	public GameObject select;
	public TextMeshProUGUI textMesh;
	public bool isWriting;
	public int randomus;
	public int writeCount;
	public int sheetCount;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI sheetText;
	public bool isFinished;
	public string lastWord;
	public bool isFirst;
	bool isZero;
	public List<Texture2D> cursorTexture;
	public BoxCollider2D boxCol;
	Vector2 hotSpot;	
	public bool menuOpen;
	
	[Header("Effects")]
	public MMFeedbacks checkFeed;
	public MMFeedbacks countFeed;
	public MMFeedbacks sheetFeed;	
	
	[Header("Lists, Words etc")]
	int bookWords;
	public List<TextMeshProUGUI> bookTexts;
	public List<string> foundWords;	
	public GameObject book;
	public TextMeshProUGUI countTextWord;	
	public Button endButton;	
	public List<TextMeshProUGUI> actionCommand;
	int commandFound;
	public List<string> foundCommands;
	
	private KeyCode Space = KeyCode.Joystick1Button0;
	
	void Start()
	{
		I = this.gameObject.GetComponent<Inventory>();
		SE = GameObject.Find("SoundSystem").GetComponent<SoundEvent>();
		int xspot = cursorTexture[0].width/2;
		int yspot = cursorTexture[0].height/2;
		Vector2 hotSpot = new Vector2(xspot,yspot);
		Cursor.SetCursor(cursorTexture[0], hotSpot, CursorMode.Auto);
		Load();
	}	
	
	void Update()
	{
		if(isZero)
		{
			theText = inputField.text.Remove(inputField.text.Length -1);
			inputField.text = theText;
			isZero = false;
		}
		
		if(Input.GetKeyUp(Space))
		{
			if(!menuOpen && !isWriting && !I.bagOpen)
			{
				OpenBook();
				//aS.clip = aC[8];
				//aS.Play();
				menuOpen = true;
			}
			else if(menuOpen && !I.bagOpen)
			{
				CloseBook();
				menuOpen = false;
				//aS.clip = aC[9];
				//aS.Play();
			}
		}	
	}
	
	void OnMouseEnter()
	{
		if(!isWriting && !isFinished)
		{
			//aS.clip = aC[7];
			//aS.Play();
		}
		
		if(!isFinished)
		{
			Cursor.SetCursor(cursorTexture[2], hotSpot, CursorMode.Auto);
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
		//aS.clip = aC[6];
		//aS.Play();
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
		isWriting = false;
		isFinished = true;
		
		if(theText == "aeiou" && !foundWords.Contains("aeiou"))
		{
			textMesh.color = Color.blue;			
			AddWord();			
		}
		
		if(theText == "lighter" && !foundWords.Contains("lighter"))
		{
			textMesh.color = Color.red;
			AddWord();
		}
		
		if(theText == "Talk" && !foundCommands.Contains("Talk"))
		{
			AddCommand();
		}
		
		if(theText == "Look" && !foundCommands.Contains("Look"))
		{
			AddCommand();
		}
		
		if(theText == "Smell" && !foundCommands.Contains("Smell"))
		{
			AddCommand();
		}
		
		if(theText == "Listen" && !foundCommands.Contains("Listen"))
		{
			AddCommand();
		}
		
		if(theText == "Touch" && !foundCommands.Contains("Touch"))
		{
			AddCommand();
		}
		
		if(theText.Length == 0)
		{
			inputField.interactable = true;
			isWriting = false;
			isFinished = false;
			//eraseButton.SetActive(false);
		}
		
		StartCoroutine(WaitCheck());

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
		else if(writeCount > 0)
		{
			playSound();
			writeCount --;
			countFeed.PlayFeedbacks();
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
		
		if(!isFirst && writeCount > 0)
		{
			SE.RandomPenScratch();
			SE.RandomPenScratch();
		}
		
		randomus = Random.Range(1,6);
		
		if(randomus == 1 && !isFirst && writeCount > 0)
		{
			//aS.clip = aC[0];
			//aS.Play();
		}
		else if(randomus == 2 && !isFirst && writeCount > 0)
		{
			//aS.clip = aC[1];
			//aS.Play();
		}
		else if(randomus == 3 && !isFirst && writeCount > 0)
		{
			//aS.clip = aC[2];
			//aS.Play();
		}
		else if(randomus == 4 && !isFirst && writeCount > 0)
		{
			//aS.clip = aC[3];
			//aS.Play();
		}
		else if(randomus == 5 && !isFirst && writeCount > 0)
		{
			//aS.clip = aC[4];
			//aS.Play();
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
			//aS.clip = aC[8];
			//aS.Play();
				menuOpen = true;
			}
		else if(menuOpen && !I.bagOpen)
			{
				CloseBook();
				menuOpen = false;
			//aS.clip = aC[9];
			//aS.Play();
			}
	}

	void AddWord()
	{
		//aS.clip = aC[5];
		//aS.Play();
		checkFeed.PlayFeedbacks();
		bookTexts[bookWords].text = theText;
		bookTexts[bookWords].color = textMesh.color;
		bookWords++;
		countTextWord.text = bookWords.ToString();
		foundWords.Add(theText);
		Save();
	}
	
	void AddCommand()
	{
		textMesh.color = Color.yellow;
		//aS.clip = aC[5];
		//aS.Play();
		checkFeed.PlayFeedbacks();
		actionCommand[commandFound].text = theText;
		actionCommand[commandFound].color = textMesh.color;
		commandFound++;
		foundCommands.Add(theText);
		Save();
	}
	
	IEnumerator WaitCheck()
	{
		yield return new WaitForSeconds(2f);
		endButton.Select();
		sheetCount--;
		sheetText.text = "x" + sheetCount.ToString();
		sheetFeed.PlayFeedbacks();
		inputField.text = null;
		theText = null;
		inputField.interactable = true;
		isWriting = false;
		isFinished = false;
		textMesh.color = Color.black;
	}
	
	void Save()
	{
		SaveData data = new SaveData();
		
		data.nbOfWrite = writeCount;
		data.nbOfSheet = sheetCount;
		data.nbOfWords = bookWords;
		data.allWordsFound = foundWords;
		data.nbOfCommands = commandFound;
		data.allCommandsFound = foundCommands;
		
		string json = JsonUtility.ToJson(data, true);
		File.WriteAllText(Application.dataPath + "/SaveFile.json", json);
	}
	
	void Load()
	{
		string json = File.ReadAllText(Application.dataPath + "/SaveFile.json");
		SaveData data = JsonUtility.FromJson<SaveData>(json);
		
		writeCount = data.nbOfWrite;
		sheetCount = data.nbOfSheet;
		bookWords = data.nbOfWords;
		commandFound = data.nbOfCommands;
		foundWords = data.allWordsFound;
		foundCommands = data.allCommandsFound;
		
		sheetText.text = "x" + sheetCount.ToString();
		countText.text = writeCount.ToString();
		countTextWord.text = bookWords.ToString();
		
		for (int i = 0; i < bookWords; i++)
		{
			bookTexts[i].text = foundWords[i];
		}
		
		for (int i = 0; i < commandFound; i++)
		{
			actionCommand[i].text = foundCommands[i];
		}
	}	
}
