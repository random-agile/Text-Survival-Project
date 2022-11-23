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
	
	void Update() // update for input
	{
		if(Input.GetKeyUp(b))
		{
			if(!bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				OpenBag();
				bagOpen = true;
			}
			else if(bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				CloseBag();
				bagOpen = false;
			}
		}
	}
	
	public void ButtonOpenBag() // function to assign onClick() to check the bag
	{
		if(!bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				OpenBag();
				bagOpen = true;
			}
		else if(bagOpen && !TIM.isWriting && !TIM.menuOpen)
			{
				CloseBag();
				bagOpen = false;
			}	
	}
	
	void SetStats() // set all stats of the player
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
	
	public void PrepLoad() // function to assign onClick() to leave the inventory
	{
		fade.SetActive(true);
		StartCoroutine(Load());
	}
	
	IEnumerator Load() // destroy clone
	{
		yield return new WaitForSeconds(1f);
		PI.isMenu = true;
		PI.isMovementLocked = false;
		Destroy(GameObject.Find("Menu(Clone)"));
	}
}

