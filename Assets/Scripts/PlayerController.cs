using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayerController : MonoBehaviour
{
	public bool smoothTransition = false;
	public float transitionSpeed = 10f;
	public float transitionRotationSpeed = 500f;
	public int playerMovement;
	
	Vector3 targetGridPos;
	Vector3 prevTargetGridPos;
	Vector3 targetRotation;
	
	public bool asMoved;
	public bool encounterSecurity;
	
	public MMFeedbacks FlashFeedback;
	EncounterManager EM;
	
	public AudioSource seSource;
	public AudioClip heartBeat;
	
	RaycastHit hitMonsterFront;
	RaycastHit hitMonsterBack;
	RaycastHit hitWallFront;
	RaycastHit hitWallBack;
	bool isWallFront;
	bool isWallBack;
	bool isMonsterBack;
	
	
	private void Start()
	{
		Application.targetFrameRate = 60;
		targetGridPos = Vector3Int.RoundToInt(transform.position);
		EM = this.GetComponent<EncounterManager>();		
	}
	
	private void Encounter()
	{
		if(!encounterSecurity)
		{
			seSource.clip = heartBeat;
			seSource.Play();
			encounterSecurity = true;
			EM.Engage();
		}
	}
	
	private void FixedUpdate()
	{				
		if (Physics.Raycast(transform.position, transform.forward, out hitMonsterFront, 20) && hitMonsterFront.transform.tag == "Creature")
		{	
			if(!isWallFront)
			{
			//Debug.Log("Did Hit Front");
			Encounter();							
			}						
		}
		else
		{
			//Debug.Log("Stop Hit Front");
			encounterSecurity = false;
		}
		
		if (Physics.Raycast(transform.position, transform.forward * -1, out hitMonsterBack, 20) && hitMonsterBack.transform.tag == "Creature")
		{	
			if(!isWallBack)
			{
				//Debug.Log("Did Hit Back");
				isMonsterBack = true;							
			}						
		}
		else
		{
			//Debug.Log("Stop Hit Back");
			isMonsterBack = false;
		}
		
		if (Physics.Raycast(transform.position, transform.forward, out hitWallFront, 15) && hitWallFront.transform.tag == "Wall")
		{
			//Debug.Log("Did Hit Wall Front");
			isWallFront = true;	
		}
		else 
		{
			//Debug.Log("Stop Wall Front");
			isWallFront = false;
		}
		
		if (Physics.Raycast(transform.position, transform.forward * -1, out hitWallBack, 15) && hitWallBack.transform.tag == "Wall")
		{
			//Debug.Log("Did Hit Wall Back");
			isWallBack = true;	
		}
		else 
		{
			//Debug.Log("Stop Wall Back");
			isWallBack = false;
		}
		
		MovePlayer();		
		
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 15, Color.red);
		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * -1) * 15, Color.blue);
	}	
			
			
	void MovePlayer()
	{
		if (true)
		{
			prevTargetGridPos = targetGridPos;
			
			Vector3 targetPosition = targetGridPos;
			
			if (targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
			if (targetRotation.y < 0f) targetRotation.y = 270f;
			
			if(!smoothTransition)
			{
				transform.position = targetPosition;
				transform.rotation = Quaternion.Euler(targetRotation);
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
			}
		}
		else
		{
			//targetGridPos = prevTargetGridPos;
		}
	}
	
	public void RotateLeft() 
	{ 
		if(AtRest) 
		{
			targetRotation -= Vector3.up * 90f; 
		}
	}
	
	public void RotateRight() 
	{ 
		if(AtRest)
		{
			targetRotation += Vector3.up * 90f; 
		}
	}
	
	public void MoveForward() 
	{ 
		if(AtRest && !isWallFront)
		{
			targetGridPos += transform.forward * playerMovement; 
			asMoved = true;
		}
	}
	
	public void MoveBackward() 
	{ 
		if(AtRest && !isWallBack && !isMonsterBack) 
		{
			targetGridPos -= transform.forward * playerMovement; 
			asMoved = true;
		}
	}
	
	bool AtRest {
		get {
			if ((Vector3.Distance(transform.position, targetGridPos) < 0.05f) &&
			(Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f))
				return true;
			else
				return false;
		}
	}
}
