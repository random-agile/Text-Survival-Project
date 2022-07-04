using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerIA : MonoBehaviour
{
	public AudioSource seSource;
	PlayerController playerController;
	PlayerInput playerInput;
	public bool stalkerState;
	public int wait;
	public GameObject redDot;
	public GameObject whiteDot;
	public GameObject map;
	bool oneTrigger;
	bool asWaited;
	bool securityWait;
	
	void Start()
	{
		playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
		playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
	}

    void Update()
	{
		
	    if (playerController.asMoved)
	    {
	    	StartCoroutine(StalkerMove());
	    }	    
	    
    }
    
	IEnumerator StalkerMove()
	{
		if (wait == 0)
		{
			StateCheck();			
			whiteDot.transform.position += new Vector3(-64f * Time.deltaTime, 0f, 0f);
			yield return new WaitForSeconds(1f);
			AbstractEnd();
			yield return new WaitForSeconds(1f);
			playerInput.EnableScript();
			Waiting();
		}
		
		else if(wait == 1)
		{
			StateCheck();
			this.transform.position += new Vector3(20f * Time.deltaTime, 0f, 0f );
			whiteDot.transform.position += new Vector3(0, 64f * Time.deltaTime, 0f);
			yield return new WaitForSeconds(1f);
			AbstractEnd();
			yield return new WaitForSeconds(1f);
			playerInput.EnableScript();
			Waiting();
		}		
	}
	
	void StateCheck()
	{		
		asWaited = false;
		map.SetActive(true);
		if(!oneTrigger)
		{
			playerInput.DisableScript();
			seSource.Play();
			oneTrigger = true;
		}
	}
	
	void AbstractEnd()
	{
		map.SetActive(false);
		playerController.asMoved = false;
		oneTrigger = false;
	}
	
	void Waiting()
	{
		if(!asWaited)
		{
			wait++;
			asWaited = true;
		}
	}
}
