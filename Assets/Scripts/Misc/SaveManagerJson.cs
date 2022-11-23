using UnityEngine;
using System.IO;
public class SaveManagerJson : MonoBehaviour
{			
	public void Save()
	{
		SaveData data = new SaveData();

		string json = JsonUtility.ToJson(data, true);
		File.WriteAllText(Application.dataPath + "/SaveFile.json", json);
	}
	
	public void Load()
	{
		string json = File.ReadAllText(Application.dataPath + "/SaveFile.json");
		SaveData data = JsonUtility.FromJson<SaveData>(json);		
	}
}
