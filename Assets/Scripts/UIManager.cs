using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour
{	
	public List<Image> highLight;
	public AudioSource seAudio;
	public List<AudioClip> seClip;
	public GameObject fade;
	
	public List<GameObject> deactivate;
	
	public Button button;
	bool lockUpdate;
	bool lockUptwo;
	bool lockUpthree;
	
	void Start()
	{
		highLight[1].enabled = false;
		highLight[2].enabled = false;

		button.Select();
		
	}
	
	void Update()
	{
		GameObject sel = EventSystem.current.currentSelectedGameObject;
		Debug.Log(sel.name);
		
		if(sel.name == "New Game")
		{
			if(lockUpdate)
			{
				HighLightOne();
				highLight[0].enabled = true;
				highLight[2].enabled = false;
				highLight[1].enabled = false;
				lockUptwo = false;
				lockUpdate = true;
				lockUpthree = false;				
			}
		}
		
		if(sel.name == "Continue")
		{
			if(lockUptwo)
			{
				HighLightOne();
				highLight[0].enabled = false;
				highLight[2].enabled = false;
				highLight[1].enabled = true;
				lockUptwo = true;
				lockUpdate = false;
				lockUpthree = false;				
			}
		}
		
		if(sel.name == "Options")
		{
			if(lockUpthree)
			{
				HighLightOne();
				highLight[0].enabled = false;
				highLight[2].enabled = true;
				highLight[1].enabled = false;
				lockUptwo = false;
				lockUpdate = false;
				lockUpthree = true;				
			}
		}
		
		
	}

	public void HighLightOne()
	{
		seAudio.clip = seClip[0];
		seAudio.Play();	
	}
	

	
	public void Select()
	{
		seAudio.clip = seClip[1];
		seAudio.Play();
		fade.SetActive(true);
		foreach (GameObject obj in deactivate)
		{
			obj.SetActive(false);
		}
		StartCoroutine(Load());
	}

	void OnMouseExit()
	{
		foreach (Image img in highLight)
		{
			img.enabled = false;					
		}
	}
	
	IEnumerator Load()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Assets/Scenes/Test.unity");
	}
	
}
