using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/*
 *		FmodEvent list:
 *		
 *		0	MusicStress
 *		1	StepEvent
 *		2	PenScratching
 *		3	TurningPage
 *		4	MinerStep
 *		5   Heartbeat
 *		6   MinerGameOver
 *
 * 
 */


public class SoundSystem : MonoBehaviour
{
	public FMOD.Studio.EventInstance instance;
	public FMOD.Studio.EventInstance bgsInstance;
	public List<FMODUnity.EventReference> fmodEvent;
	
	public bool asWait;
	
	public void PlaySE(string name)
	{
		switch (name)
		{
			case "StepEvent":
				instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent[1]);
				instance.start();
				instance.release();
				break;

			case "PenScratching":
				FMODUnity.RuntimeManager.PlayOneShot(fmodEvent[2]);
				break;
				
			case "TurningPage":
				instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent[3]);
				instance.start();
				instance.release();
				break;
				
			case "Heartbeat":
				instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent[4]);
				instance.start();
				instance.release();
				break;
				
			case "MinerGameOver":
				instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent[5]);
				instance.start();
				instance.release();
				break;
				
			
		}
	}
	

	public void PlayBGM(string name)
	{
		switch (name)
		{
			case "une musique":

				break;

			case "etc...":

				break;
		}
	}

	public void PlayBGS(string name)
	{
		switch (name)
		{
			case "MusicStress":
				bgsInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent[0]);
				bgsInstance.start();
				break;

			case "etc...":

				break;
		}
	}
	
	public void StopBGS(string name)
	{
		switch (name)
		{
		case "MusicStress":
			bgsInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
			break;
		}
	}

}