using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PlayerController : MonoBehaviour
{
	MonsterPattern MP;
	
	public bool smoothTransition = false;
	public float transitionSpeed = 10f;
	public float transitionRotationSpeed = 500f;
	public int playerMovement;
	
	Vector3 targetGridPos;
	//Vector3 prevTargetGridPos;
	Vector3 targetRotation;
	Vector3 actualRotation;
	
	public bool asMoved;
	public bool asRotated;
	public bool encounterSecurity;
	public bool isInteraction;
	
	public MMFeedbacks FlashFeedback;
	//EncounterManager EM;
	
	RaycastHit hitMonsterFront;
	RaycastHit hitMonsterBack;
	RaycastHit hitWallFront;
	RaycastHit hitWallBack;
	bool isWallFront;
	bool isWallBack;
	bool isMonsterBack;
	
	public GameObject hud;
	
	private void Start()
	{
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 1;
		targetGridPos = Vector3Int.RoundToInt(transform.position);
		MP = GameObject.Find("Miner").GetComponent<MonsterPattern>();
		//EM = this.GetComponent<EncounterManager>();		
	}
	
	private void Encounter() // play heartbeat before encounter
	{
		if(!encounterSecurity)
		{
			//seSource.clip = heartBeat;
			//seSource.Play();
			encounterSecurity = true;
			//EM.Engage();
		}
	}
	
	private void FixedUpdate() // raycast checking position front and back
	{				
		if (Physics.Raycast(transform.position, transform.forward, out hitMonsterFront, 20) && hitMonsterFront.transform.tag == "Creature")
		{	
			if(!isWallFront)
			{
			Encounter();							
			}						
		}
		else
		{
			encounterSecurity = false;
		}
		
		if (Physics.Raycast(transform.position, transform.forward * -1, out hitMonsterBack, 20) && hitMonsterBack.transform.tag == "Creature")
		{	
			if(!isWallBack)
			{
				isMonsterBack = true;							
			}						
		}
		else
		{
			isMonsterBack = false;
		}
		
		if (Physics.Raycast(transform.position, transform.forward, out hitWallFront, 15) && hitWallFront.transform.tag == "Wall")
		{
			isWallFront = true;	
		}
		else 
		{
			isWallFront = false;
		}
		
		if (Physics.Raycast(transform.position, transform.forward * -1, out hitWallBack, 15) && hitWallBack.transform.tag == "Wall")
		{
			isWallBack = true;	
		}
		else 
		{
			isWallBack = false;
		}
		
		MovePlayer();	
		
		if(transform.position == targetGridPos && !isInteraction)
		{
			asMoved = false;
			asRotated = false;
			MP.moveSecure = false;
			hud.SetActive(true);
		}
		
		if(transform.eulerAngles != targetRotation)
		{
			asRotated = true;
			hud.SetActive(false);
		}
		
		
		Debug.DrawRay(transform.position, transform.forward * 15, Color.red);
		Debug.DrawRay(transform.position, transform.forward * -1 * 15, Color.blue);
	}	
			
			
	void MovePlayer() // move up, down, left, right the player
	{
		if (true)
		{
			//prevTargetGridPos = targetGridPos;
			Vector3 targetPosition = targetGridPos;
			
			if (targetRotation.y > 270f && targetRotation.y < 361f) 
			{
				targetRotation.y = 0f;
			}
			if (targetRotation.y < 0f) 
			{
				targetRotation.y = 270f;
			}
			
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
			asRotated = true;
			hud.SetActive(false);
		}
	}
	
	public void RotateRight() 
	{ 
		if(AtRest)
		{
			targetRotation += Vector3.up * 90f; 
			asRotated = true;
			hud.SetActive(false);
		}
	}
	
	public void MoveForward() 
	{ 
		if(AtRest && !isWallFront)
		{
			targetGridPos += transform.forward * playerMovement; 
			asMoved = true;
			hud.SetActive(false);
		}
	}
	
	public void MoveBackward() 
	{ 
		if(AtRest && !isWallBack && !isMonsterBack) 
		{
			targetGridPos -= transform.forward * playerMovement; 
			asMoved = true;
			hud.SetActive(false);
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
