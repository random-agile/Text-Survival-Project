using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
	public KeyCode forward = KeyCode.UpArrow;
	public KeyCode backward = KeyCode.DownArrow;
	public KeyCode turnLeft = KeyCode.LeftArrow;
	public KeyCode turnRight = KeyCode.RightArrow;
	public Vector3 pos;
	
	void Update()
	{
		if(Input.GetKeyUp(forward)) MoveForward();
		if(Input.GetKeyUp(backward)) MoveBackward();
		if(Input.GetKeyUp(turnLeft)) RotateLeft();
		if(Input.GetKeyUp(turnRight)) RotateRight();
	}
	
	void MoveForward()
	{
		//pos = (0,1,0);
		this.gameObject.transform.position+=Vector3.forward;
	}
	
	void MoveBackward()
	{
		this.gameObject.transform.position+=Vector3.back;
	}
	
	void RotateLeft()
	{
		
	}
	
	void RotateRight()
	{
		
	}


}
