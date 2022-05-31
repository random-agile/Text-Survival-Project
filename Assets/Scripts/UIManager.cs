using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{	
	public Image sprite;
	public AudioSource seAudio;
	public AudioClip valid;
	public AudioClip move;
	public GameObject fade;
	public BoxCollider2D boxCol;
	
	public List<GameObject> deactivate;
	
	void Start()
	{
		boxCol = this.GetComponent<BoxCollider2D>();
		sprite = this.GetComponent<Image>();
		sprite.enabled = false;
	}
	

	void OnMouseEnter()
	{
		seAudio.clip = move;
		seAudio.Play();
	}
	
	void OnMouseOver()
	{
		sprite.enabled = true;
	}
	
	void OnMouseDown()
	{
		seAudio.clip = valid;
		seAudio.Play();
		fade.SetActive(true);
		foreach (GameObject obj in deactivate)
		{
			obj.SetActive(false);
		}
		StartCoroutine(Load());
		boxCol.enabled = false;
	}

	void OnMouseExit()
	{
		sprite.enabled = false;
	}
	
	IEnumerator Load()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Assets/Scenes/Test.unity");
	}
	
}
