using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterPattern : MonoBehaviour
{
	PlayerController PC;
	SoundSystem SS;
	MinerSpriteManager MSM;
	RaycastHit playerSearch;
	public bool detectionSecure;
	public bool moveSecure;
	string move;
	public List<string> moveInstructions;
	Vector3 nextPos;
	Vector3 beginPos;
	Vector3 playerPos;
	
	public GameObject invert;
	public GameObject deadScreen;
	public GameObject gameOver;

	public FMODUnity.EventReference fmodEvent;
	
	bool isWait;
	bool isDead;

	
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
		
		if(Physics.Raycast(transform.position, transform.forward *-1, out playerSearch, 55) && playerSearch.transform.tag == "Player" && !detectionSecure)
		{
			playerPos = playerSearch.transform.position;
	    	PlayerDetected();
	    	detectionSecure = true;
	    }
	    
	    if(PC.asMoved && !moveSecure)
	    {
	    	MoveMonster();
	    	moveSecure = true;
	    }
	    
		if(isWait && detectionSecure)
		{
			this.transform.position -= new Vector3(10f * Time.deltaTime * 4, 0f, 0f);
		}
		
		if(isDead)
		{
			deadScreen.SetActive(true);
			gameOver.SetActive(true);
		}
	    
		Debug.DrawRay(transform.position, transform.forward*-1, Color.red, 50);
	    
    }
    
	void PlayerDetected()
	{
		SS.StopBGS("MusicStress");
		MSM.stopAnim();
		invert.SetActive(true);
		SS.PlaySE("Heartbeat");
		SS.PlaySE("Heartbeat");
		StartCoroutine(WaitDetection());
	}
    
	void MoveMonster()
	{
		FMODUnity.RuntimeManager.PlayOneShotAttached(fmodEvent, this.gameObject);
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
	
	IEnumerator WaitDetection()
	{
		yield return new WaitForSeconds(2f);
		SS.PlaySE("MinerGameOver");
		SS.PlaySE("MinerGameOver");
		MSM.resumeAnim();
		invert.SetActive(false);
		isWait = true;
		yield return new WaitForSeconds(1f);
		isDead = true;
		yield return new WaitForSeconds(10f);
		SceneManager.LoadScene(0);
	}
}
