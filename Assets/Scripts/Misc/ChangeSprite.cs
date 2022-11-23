using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
	public SpriteRenderer originalSprite;
	public List<Sprite> spriteList;	
	private int completed;
	private int wait;
	public GameObject empty;
	public Transform pos;
	
    void Start() // Initialize Sprite and Get the position to look at for the sprite
	{
		originalSprite.sprite = spriteList[0];
		completed++;
		pos = empty.GetComponent<Transform>();
	}
    
	void Update() // Increment "wait" so that each 20 frames the sprite change
	{
		wait++;
		if(wait == 20){ChangingSprite(); wait = 0;}
		transform.LookAt(2 * transform.position - pos.position);
	}
	
	void ChangingSprite() // Cycle of sprite animation depending on the size of the list
	{
		if(completed == spriteList.Count)
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
