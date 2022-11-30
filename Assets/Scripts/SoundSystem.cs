using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
	public FMOD.Studio.EventInstance instance;
	public List<FMODUnity.EventReference> fmodEvent;
	
	public void PlaySE(string name)
	{
		switch (name)
		{
			case "StepEvent":
				instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent[1]);
				break;

			case "etc...":

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
				instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent[0]);
				instance.start();

				break;

			case "etc...":

				break;
		}
	}



	// r�sultat final dans les autres scripts : SS.PlaySE(surmulot);
}