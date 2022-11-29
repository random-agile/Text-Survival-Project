using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    public SoundSystem SS;
    public PlayerStats PS;
    // Start is called before the first frame update
    void Awake()
    {
        SS = gameObject.GetComponent<SoundSystem>();
        PS = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    void Start()
    {
        SS.PlayBGS("MusicStress");    
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.stress >= 75)
        {
            SS.instance.setParameterByName("Rng", 1);
        }
        else SS.instance.setParameterByName("Rng", 0);

    }
}
