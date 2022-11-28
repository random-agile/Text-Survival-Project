using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
	[Header("Inputs Key")]
	public KeyCode forward = KeyCode.UpArrow;
	public KeyCode backward = KeyCode.DownArrow;
	public KeyCode turnLeft = KeyCode.LeftArrow;
	public KeyCode turnRight = KeyCode.RightArrow;
	public KeyCode items = KeyCode.F2;

	[Header("References")]
	//public AudioSource aS;
	public List <AudioClip> aC;
	public GameObject fadeOut;
	public List<GameObject> transitionObjects;
	public GameObject menu;
	public bool isMovementLocked;
	public bool isMenu;
	public bool isItemMenu;
	public GameObject HUD;
	public GameObject ItemHUD;
	public GameObject ItemSelect;
	
	PlayerController controller;
	
	private void Awake()
	{
	    controller = GetComponent<PlayerController>();
    }

	private void Update() // input taken at every frame
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
    
	public void OpenItems() // open item menu
	{
		//aS.clip = aC[0];
		//aS.Play();
		isMovementLocked = true;
		isItemMenu = true;
		HUD.SetActive(false);
		ItemHUD.SetActive(true);
		EventSystem.current.SetSelectedGameObject(ItemSelect);
	}
	
	public void CloseItems() // close item menu
	{
		//aS.clip = aC[1];
		//aS.Play();
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
	
	public void Loaded() // function to attribute on click for loading writing menu
	{
		fadeOut.SetActive(true);
		StartCoroutine(Loadings());
	}	
	
	IEnumerator Loadings() // launch writing menu
	{
		isMovementLocked = true;
		yield return new WaitForSeconds(1f);
		fadeOut.SetActive(false);
		foreach (var obj in transitionObjects)
		obj.SetActive(false);
		Instantiate(menu);
	}
	
	public void ExitMenu() // exit writing menu
	{
		foreach (var obj in transitionObjects)
			obj.SetActive(true);
	}
}
