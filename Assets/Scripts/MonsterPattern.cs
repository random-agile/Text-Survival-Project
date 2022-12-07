using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPattern : MonoBehaviour
{
	PlayerController PC;
	SoundSystem SS;
	MinerSpriteManager MSM;
	RaycastHit playerSearch;
	bool detectionSecure;
	public bool moveSecure;
	string move;
	public List<string> moveInstructions;
	Vector3 nextPos;
	Vector3 beginPos;
	
	void Awake()
	{
		beginPos = this.transform.position;
		nextPos = this.transform.position;
		SS = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
		PC = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		MSM = this.GetComponent<MinerSpriteManager>();
    }


    void Update()
	{
		    	
		if(moveInstructions.Count == 0 && !moveSecure)
		{
			this.transform.position = beginPos;
			MinerPatternLoad();
		}
		
		if(PC.asMoved && move == "Up")
		{
			this.transform.position += new Vector3(0f, 0f, 5f * Time.deltaTime * 2);
		}
		
		if(PC.asMoved && move == "Down")
		{
			this.transform.position -= new Vector3(0f, 0f, 5f * Time.deltaTime * 2);
		}
		
		if(PC.asMoved && move == "Right")
		{
			this.transform.position += new Vector3(5f * Time.deltaTime * 2, 0f, 0f);
		}
		
		if(PC.asMoved && move == "Left")
		{
			this.transform.position -= new Vector3(5f * Time.deltaTime * 2, 0f, 0f);
		}
		
	    if(Physics.Raycast(transform.position, transform.forward, out playerSearch, 20) && playerSearch.transform.tag == "Player" && !detectionSecure)
	    {
	    	PlayerDetected();
	    	detectionSecure = true;
	    }
	    
	    if(PC.asMoved && !moveSecure)
	    {
	    	MoveMonster();
	    	moveSecure = true;
	    }
    }
    
	void PlayerDetected()
	{
		
	}
    
	void MoveMonster()
	{
		move = moveInstructions[0];			
		moveInstructions.RemoveAt(0);
	}
	
	void MinerPatternLoad()
	{
		for(int i=0;i<6;i++)
		{
			moveInstructions.Add("Up");
		}
		
		for(int i=0;i<6;i++)
		{
			moveInstructions.Add("Left");
		}
		
		for(int i=0;i<6;i++)
		{
			moveInstructions.Add("Down");
		}
		
		for(int i=0;i<6;i++)
		{
			moveInstructions.Add("Up");
		}
		
		for(int i=0;i<6;i++)
		{
			moveInstructions.Add("Right");
		}
		
		for(int i=0;i<6;i++)
		{
			moveInstructions.Add("Down");
		}		
	}
}
