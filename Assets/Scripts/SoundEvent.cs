using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    public SoundSystem SS;
    public PlayerStats PS;
    public PlayerController PC;
    int rng = 0;
    bool asPlayStepSound;

    void Awake()
    {
        SS = gameObject.GetComponent<SoundSystem>();
        PS = GameObject.Find("Player").GetComponent<PlayerStats>();
        PC = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    void Start()
    {
        SS.PlayBGS("MusicStress");    
    }

   

    void Update()
    {
        if (PS.stress >= 75)
        {
            SS.instance.setParameterByName("Rng", 1);
        }
        else SS.instance.setParameterByName("Rng", 0);


	    if (PC.asMoved && !asPlayStepSound)
	    {
	    	SS.PlaySE("StepEvent");
	    	asPlayStepSound = true;
	    }
        
	    if(!PC.asMoved)
	    {
	    	asPlayStepSound = false;
	    	SS.instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
	    }
    }
  

	public void RandomPenScratch()
    {
	    rng = Random.Range(0,4);
	    SS.instance.setParameterByName("RandomTrigger", rng);
	    SS.PlaySE("PenScratching");
    }
}
