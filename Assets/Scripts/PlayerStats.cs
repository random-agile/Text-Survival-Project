using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	[Header("Stats")]
	public int hp = 100;
	public int hpMax = 100;
	public int stress = 0;
	public int stressMax = 100;
	public int thirst = 0;
	public int will = 1;
	public int conviction = 1;
	public int dexterity = 1;

	[Header("Texts")]
	public TMP_Text hpText;
	public TMP_Text spText;

	[Header("Sliders")]
	public Slider hpSlider;
	public Slider spSlider;
	
	void Awake() // assign value to slider
	{
		hpText.text = hpSlider.value.ToString();
		spText.text = spSlider.value.ToString();
	}	
}

