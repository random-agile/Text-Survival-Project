using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
	private KeyCode b = KeyCode.Escape;
	bool bagOpen;
	public AudioSource aS;
	public List<AudioClip> aC;
	public GameObject bag;
	
	TextInputManager TIM;
	PlayerStats PS;
	
	public List <TextMeshProUGUI> statsText;
	
	void Start()
	{
		TIM = this.gameObject.GetComponent<TextInputManager>();
		PS = this.gameObject.GetComponent<PlayerStats>();
		
		statsText[0].text = "Health  " + PS.hp.ToString();
		statsText[1].text = "Stress   " + PS.stress.ToString();
		statsText[2].text = "Will             " + PS.will.ToString();
		statsText[3].text = "Conviction  " + PS.conviction.ToString();
		statsText[4].text = "Dexterity    " + PS.dexterity.ToString();
	}
	
	void Update()
	{
		if(Input.GetKeyUp(b))
		{
			if(!bagOpen && !TIM.isWriting)
			{
				OpenBag();
				//aS.clip = aC[0];
				//aS.Play();
				bagOpen = true;
			}
			else if(bagOpen && !TIM.isWriting)
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
		if(!bagOpen && !TIM.isWriting)
			{
				OpenBag();
				//aS.clip = aC[0];
				//aS.Play();
				bagOpen = true;
			}
		else if(bagOpen && !TIM.isWriting)
			{
				CloseBag();
				bagOpen = false;
				//aS.clip = aC[0];
				//aS.Play();
			}	
	}
	
	
	void OpenBag()
	{
		bag.SetActive(true);
	}
	
	void CloseBag()
	{
		bag.SetActive(false);		
	}
}

