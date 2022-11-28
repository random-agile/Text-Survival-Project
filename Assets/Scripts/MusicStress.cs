using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStress : MonoBehaviour
{
    public bool isStressed = false;
    private FMOD.Studio.EventInstance instance;
    public FMODUnity.EventReference fmodEvent;
    public PlayerStats PS;

    void Awake()
    {
        PS = GameObject.Find("Player").GetComponent<PlayerStats>();
        
    }
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.stress >= 75) {
            isStressed = true;
        }
        else isStressed = false;

        if (isStressed)
        {
            instance.setParameterByName("Rng",1);
        }
        else instance.setParameterByName("Rng", 0);
    }
}
