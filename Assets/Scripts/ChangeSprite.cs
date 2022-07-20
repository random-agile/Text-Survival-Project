using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
	public SpriteRenderer originalSprite;
	public List<Sprite> spriteList;	
	private int completed;
	private int wait;
	//private GameObject player;
	//private Transform pos;
	public GameObject empty;
	public Transform pos;
	
    void Start()
	{
		originalSprite.sprite = spriteList[0];
		completed++;
		//player = GameObject.FindWithTag("Player");
		//pos = player.GetComponent<Transform>();
		pos = empty.GetComponent<Transform>();
	}
    
	void Update()
	{
		wait++;
		if(wait == 20){ChangingSprite(); wait = 0;}
		transform.LookAt(2 * transform.position - pos.position);
	}
	
	void ChangingSprite()
	{
		if(completed == 3)
		{
			originalSprite.sprite = spriteList[completed]; 
			completed = 0;
		}
		else
		{
			originalSprite.sprite = spriteList[completed]; 
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
