using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerManager : MonoBehaviour
{
	public SpriteRenderer originalSprite;
	public List<Sprite> idleList;	
	public List<Sprite> attackList;	
	public List<Sprite> hitList;	
	public List<Sprite> deathList;	
	private int completed;
	private int wait;
	public int state;
	private GameObject player;
	private Transform pos;
	public Animator anims;
	
	
	void Start()
	{
		originalSprite.sprite = idleList[0];
		player = GameObject.FindWithTag("Player");
		pos = player.GetComponent<Transform>();
	}
    
	void Update()
	{
		wait++;
		if(wait == 20){ChangingState(); wait = 0;}
		transform.LookAt(2 * transform.position - pos.position);
		
	}
	
	void ChangingState()
	{
		if(state == 0)
		{
			IdleSprite();
		}
		else if(state == 1)
		{
			AttackSprite();
		}
		else if (state == 2)
		{
			HitSprite();
		}
		else if (state == 3)
		{
			DeathSprite();
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
		if(completed == 2)
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
