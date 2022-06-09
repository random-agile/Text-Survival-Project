using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;

public class TtitleScreenManager : MonoBehaviour
{
	public AudioSource seAudio;
	
	public List<AudioClip> seClip;
	
	public GameObject fade;
	
	public List<GameObject> deactivate;
	
	public MMFeedbacks flash;
	
	bool isFirst;
	
	public void Select()
	{
		flash.PlayFeedbacks();
		seAudio.clip = seClip[1];
		seAudio.Play();
		fade.SetActive(true);
		foreach (GameObject obj in deactivate)
		{
			obj.SetActive(false);
		}
		StartCoroutine(Load());
	}
	
	public void HighLight()
	{
		if(!isFirst)
		{
			isFirst = true;
		}
		else if(isFirst)
		{
		seAudio.clip = seClip[0];
			seAudio.Play();
		}
	}
	
	IEnumerator Load()
	{
		yield return new WaitForSeconds(4f);
		SceneManager.LoadScene("Assets/Scenes/Test.unity");
	}
}