using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
	
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Start()
	{		
		Data data = new Data();
		data.health = 100;		
		
		string json = JsonUtility.ToJson(data);
		
		
		
		
		
		//Data loadedData = JsonUtility.FromJson<Data>(json);
	}
	
	public void Save()
	{
		//File.WriteAllText(Application.dataPath + "/saveFile.json", json);
	}
	
	public void Load()
	{
		string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
	}
	
	private class Data
	{
		public int health;
	}
}
