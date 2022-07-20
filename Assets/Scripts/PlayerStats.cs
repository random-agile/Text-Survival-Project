using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public int hp = 100;
	public int hpMax = 100;
	public int stress = 0;
	public int stressMax = 100;
	public int thirst = 0;
	public int will = 1;
	public int conviction = 1;
	public int dexterity = 1;
	public Vector3 pos;
	public Quaternion rot;
	public Vector3 scale;
	
	public TMP_Text hpText;
	public TMP_Text spText;
	
	public Slider hpSlider;
	public Slider spSlider;
	
	void Awake()
	{
		hpText.text = hpSlider.value.ToString();
		spText.text = spSlider.value.ToString();
	}
	
	/*void Awake()
	{		
		string json = File.ReadAllText(Application.dataPath + "/PosFile.json");
		PosData data = JsonUtility.FromJson<PosData>(json);
		
		pos = data.playerPos;
		rot = data.playerRot;
		scale = data.playerScale;
		
		this.gameObject.transform.position = pos;
		this.gameObject.transform.rotation = rot;
		this.gameObject.transform.localScale = scale;
	}
	*/
	
}

