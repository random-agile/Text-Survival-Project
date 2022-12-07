using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerSpriteManager : MonoBehaviour
{
	public SpriteRenderer originalSprite;
	public List<Sprite> idleList;	
	public List<Sprite> attackList;	
	public List<Sprite> hitList;	
	public List<Sprite> deathList;	
	private int completed;
	private int wait;
	public int state;
	public Transform pos;
	public Animator anims;
	
	void Start()
	{
		originalSprite.sprite = idleList[0];
	}
   
	void Update() // every 20 frame change sprite + sprite look at the player every frames
	{
		wait++;
		if(wait == 20){ChangingState(); wait = 0;}
		transform.LookAt(2 * transform.position - pos.position);
	}	

	void ChangingState() // control state of the animation with the variable "state"
	{
		switch(state)
        {
			case 0:
				IdleSprite();
				break;

			case 1:
				AttackSprite();
				break;

			case 2:
				HitSprite();
				break;

			case 3:
				DeathSprite();
				break;
		}
	}

	void IdleSprite()
	{
		if(completed == 3)
		{
			originalSprite.sprite = idleList[completed]; 
			completed = 0;
		}
		else
		{
			originalSprite.sprite = idleList[completed]; 
			completed++;
		}
	}	

	void AttackSprite()
	{
		if(completed == 3)
		{
			originalSprite.sprite = attackList[completed]; 
			completed = 0;
		}
		else
		{
			originalSprite.sprite = attackList[completed]; 
			completed++;
		}
	}
	
	void HitSprite()
	{
		if(completed == 3)
		{
			originalSprite.sprite = hitList[completed]; 
			completed = 0;
		}
		else
		{
			originalSprite.sprite = hitList[completed]; 
			completed++;
		}
	}
	
	void DeathSprite()
	{
		if(completed == 3)
		{
			originalSprite.sprite = deathList[completed]; 
			anims.enabled = true;
		}
		else
		{
			originalSprite.sprite = deathList[completed]; 
			completed++;
		}
	}
	
	public void stopAnim()
	{
		enabled = false;
	}
	
	public void resumeAnim()
	{
		enabled = true;
	}
}
