using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    public SoundSystem SS;
    public PlayerStats PS;

    void Awake()
    {
        SS = gameObject.GetComponent<SoundSystem>();
        PS = GameObject.Find("Player").GetComponent<PlayerStats>();
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

    }
}
