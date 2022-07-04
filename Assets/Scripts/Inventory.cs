using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
	private KeyCode b = KeyCode.LeftAlt;
	public bool bagOpen;
	public AudioSource aS;
	public List<AudioClip> aC;
	public GameObject bag;
	
	TextInputManager TIM;
	PlayerStats PS;
	PlayerInput PI;
	
	public GameObject fade;
	
	public List <TextMeshProUGUI> statsText;
	
	void Start()
	{
		TIM = this.gameObject.GetComponent<TextInputManager>();
		PS = this.gameObject.GetComponent<PlayerStats>();
		PI = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
		SetStats();
	}
	
	void Update()
	{
		if(Input.GetKeyUp(b))
		{
			if(!bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				OpenBag();
				//aS.clip = aC[0];
				//aS.Play();
				bagOpen = true;
			}
			else if(bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				CloseBag();
				bagOpen = false;
				//aS.clip = aC[0];
				//aS.Play();
			}
		}
	}
	
	public void ButtonOpenBag()
	{
		if(!bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				OpenBag();
				//aS.clip = aC[0];
				//aS.Play();
				bagOpen = true;
			}
		else if(bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				CloseBag();
				bagOpen = false;
				//aS.clip = aC[0];
				//aS.Play();
			}	
	}
	
	void SetStats()
	{
		statsText[0].text = "Health  " + PS.hp.ToString();
		statsText[1].text = "Stress   " + PS.stress.ToString();
		statsText[2].text = "Will             " + PS.will.ToString();
		statsText[3].text = "Conviction  " + PS.conviction.ToString();
		statsText[4].text = "Dexterity    " + PS.dexterity.ToString();
	}
	
	
	void OpenBag()
	{
		bag.SetActive(true);
	}
	
	void CloseBag()
	{
		bag.SetActive(false);		
	}
	
	public void PrepLoad()
	{
		fade.SetActive(true);
		StartCoroutine(Load());
	}
	
	IEnumerator Load()
	{
		yield return new WaitForSeconds(1f);
		PI.isMenu = true;
		Destroy(GameObject.Find("Menu(Clone)"));
	}
}

