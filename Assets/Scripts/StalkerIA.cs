using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerIA : MonoBehaviour
{
	public AudioSource seSource;
	public AudioClip seFoots;
	PlayerController playerController;
	PlayerInput playerInput;
	public bool stalkerState;
	public int wait;
	bool oneTrigger;
	bool asWaited;
	bool securityWait;
	public List <GameObject> menu;
	
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
			foreach (var obj in menu)
			{
				obj.SetActive(false);
			}
			StateCheck();			
			yield return new WaitForSeconds(1f);
			AbstractEnd();
			yield return new WaitForSeconds(1f);
			playerInput.EnableScript();
			Waiting();
		}
		
		else if(wait == 1)
		{
			foreach (var obj in menu)
			{
				obj.SetActive(false);
			}
			StateCheck();
			this.transform.position += new Vector3(20f * Time.deltaTime, 0f, 0f );
			yield return new WaitForSeconds(1f);
			AbstractEnd();
			yield return new WaitForSeconds(1f);
			playerInput.EnableScript();
			Waiting();
			wait = 0;
		}		
	}
	
	void StateCheck()
	{		
		asWaited = false;
		if(!oneTrigger)
		{
			playerInput.DisableScript();
			seSource.clip = seFoots;
			seSource.Play();
			oneTrigger = true;
		}
	}
	
	void AbstractEnd()
	{
		playerController.asMoved = false;
		oneTrigger = false;
	}
	
	void Waiting()
	{
		if(!asWaited)
		{
			foreach (var obj in menu)
			{
				obj.SetActive(true);
			}
			wait++;
			asWaited = true;
		}
	}
}
