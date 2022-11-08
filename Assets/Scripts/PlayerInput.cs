using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
	public KeyCode forward = KeyCode.UpArrow;
	public KeyCode backward = KeyCode.DownArrow;
	public KeyCode turnLeft = KeyCode.LeftArrow;
	public KeyCode turnRight = KeyCode.RightArrow;
	public KeyCode items = KeyCode.A;
	
	public AudioSource aS;
	public List <AudioClip> aC;
	public GameObject fadeOut;
	public List<GameObject> transitionObjects;
	public GameObject menu;
	public bool isMovementLocked;
	public bool isMenu;
	public bool isItemMenu;
	ItemsSystem IS;
	public GameObject HUD;
	public GameObject ItemHUD;
	public GameObject ItemSelect;
	
	PlayerController controller;
	
	private void Awake()
	{
	    controller = GetComponent<PlayerController>();
	    IS = this.GetComponent<ItemsSystem>();
    }

	private void Update()
	{
		if(!isMovementLocked)
		{
	    if(Input.GetKeyUp(forward)) controller.MoveForward();
	    if(Input.GetKeyUp(backward)) controller.MoveBackward();
	    if(Input.GetKeyUp(turnLeft)) controller.RotateLeft();
		if(Input.GetKeyUp(turnRight)) controller.RotateRight();
		}
		
		if(Input.GetKeyUp(items)) 
		{	
			if(!isItemMenu)
			{
				OpenItems();
			}
			else
			{
				CloseItems();
			}	 
		}	    
		
		if(isMenu)
		{
			ExitMenu();
			isMenu = false;
		}
		
	}
    
	public void OpenItems()
	{
		aS.clip = aC[0];
		aS.Play();
		isMovementLocked = true;
		isItemMenu = true;
		HUD.SetActive(false);
		ItemHUD.SetActive(true);
		EventSystem.current.SetSelectedGameObject(ItemSelect);
	}
	
	public void CloseItems()
	{
		aS.clip = aC[1];
		aS.Play();
		isMovementLocked = false;
		isItemMenu = false;
		HUD.SetActive(true);
		ItemHUD.SetActive(false);
	}
    
	public void EnableScript()
	{
		enabled = true;
	}
	
	public void DisableScript()
	{
		enabled = false;
	}
	
	public void Loaded()
	{
		fadeOut.SetActive(true);
		StartCoroutine(Loadings());
	}	
	
	IEnumerator Loadings()
	{
		/*PosData data = new PosData();
		
		data.playerPos = this.gameObject.transform.position;
		data.playerRot = this.gameObject.transform.rotation;
		data.playerScale = this.gameObject.transform.localScale;
		
		string json = JsonUtility.ToJson(data, true);
		File.WriteAllText(Application.dataPath + "/PosFile.json", json);
		*/
		isMovementLocked = true;
		yield return new WaitForSeconds(1f);
		fadeOut.SetActive(false);
		foreach (var obj in transitionObjects)
			obj.SetActive(false);
		Instantiate(menu);
		
		//SceneManager.LoadScene("Assets/Scenes/Experimental Chaos.unity");		
	}
	
	public void ExitMenu()
	{
		foreach (var obj in transitionObjects)
			obj.SetActive(true);
	}
}
