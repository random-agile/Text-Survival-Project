using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
	public GameObject dialogBox;
	PlayerController PC;
	//ChangeSprite CS;
	MinerManager MM;
	public WriteDialog WD;
	private bool lockUpdate;
	public GameObject invert;
	public AudioSource bgsSource;
	public AudioSource seSource;
	public AudioClip DEATHMARK;
	public AudioClip nextPage;

    void Start()
	{
	    PC = this.GetComponent<PlayerController>();
		//CS = GameObject.Find("UomoTwins").GetComponent<ChangeSprite>();
		MM = GameObject.Find("Miner").GetComponent<MinerManager>();
		//dialogBox.SetActive(true);
		//dialogBox.SetActive(false);
    }
    
	public void Engage()
	{
		StartCoroutine(StartBattle());
	}
    
	IEnumerator StartBattle()
	{
		if(!lockUpdate)
		{
			//lockUpdate = true;
			bgsSource.Stop();
			MM.stopAnim();
			invert.SetActive(true);
			yield return new WaitForSeconds(2f);			
			BattlePreps();
		}
	}
	
	void BattlePreps()
	{
		bgsSource.clip = DEATHMARK;
		bgsSource.Play();
		MM.resumeAnim();
		invert.SetActive(false);
		StartCoroutine(BattleIntro());
	}
	
	IEnumerator BattleIntro()
	{
		yield return new WaitForSeconds(1.5f);
		seSource.clip = nextPage;
		seSource.Play();
		dialogBox.SetActive(true);		
	}
}
