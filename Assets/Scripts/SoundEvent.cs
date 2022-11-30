﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    public SoundSystem SS;
    public PlayerStats PS;
    public PlayerController PC;
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


        if (PC.asMoved)
            if (!asPlayStepSound)
            {
                SS.PlaySE("StepEvent");
                SS.instance.start();
                asPlayStepSound = true;
            }
            else
            {
                SS.instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                asPlayStepSound = false;
            }
           
    }
  

    IEnumerator StepEvent()
    {
        PC.asMoved = false;
        SS.PlaySE("StepEvent");
        yield return new WaitForSeconds(2.0f);
    }
}
