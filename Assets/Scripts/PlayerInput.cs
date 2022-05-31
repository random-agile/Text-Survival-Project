using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
	public KeyCode forward = KeyCode.UpArrow;
	public KeyCode backward = KeyCode.DownArrow;
	public KeyCode turnLeft = KeyCode.LeftArrow;
	public KeyCode turnRight = KeyCode.RightArrow;
	
	PlayerController controller;
	
	private void Awake()
    {
	    controller = GetComponent<PlayerController>();
    }

	private void Update()
    {
	    if(Input.GetKeyUp(forward)) controller.MoveForward();
	    if(Input.GetKeyUp(backward)) controller.MoveBackward();
	    if(Input.GetKeyUp(turnLeft)) controller.RotateLeft();
	    if(Input.GetKeyUp(turnRight)) controller.RotateRight();
    }
    
	public void EnableScript()
	{
		enabled = true;
	}
	
	public void DisableScript()
	{
		enabled = false;
	}
}
