using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class TitleScreenManager : MonoBehaviour
{
	public GameObject fade;	
	public List<GameObject> deactivate;	
	public MMFeedbacks flash;
	
	public GameObject loadingScreen;
	public GameObject loadingBarItem;
	public Slider loadingBar;
	
	bool isFirst;
	
	public void LoadScene(int sceneId)
	{
		StartCoroutine(LoadSceneAsync(sceneId));
	}
	
	public void Select() // Select Menu Option
	{
		flash.PlayFeedbacks();
		fade.SetActive(true);
		foreach (GameObject obj in deactivate)
		{
			obj.SetActive(false);
		}
		LoadScene(1);
	}
	
	public void HighLight() // Display stuff when mouse highlight element
	{
		if(!isFirst)
		{
			isFirst = true;
		}
		else if(isFirst)
		{
		}
	}
	
	IEnumerator LoadSceneAsync(int sceneId)
	{
		yield return new WaitForSeconds(2f);
		
		loadingScreen.SetActive(true);
		
		yield return new WaitForSeconds(8f);
		loadingBarItem.SetActive(true);
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
		
		while(!operation.isDone)
		{
			float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
			
			loadingBar.value = progressValue;
			Debug.Log(progressValue);
			
			yield return null;
		}
	}
	
	
}