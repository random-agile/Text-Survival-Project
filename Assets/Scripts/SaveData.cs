using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
	public int nbOfErase;
	public int nbOfWrite;
	public int nbOfWords;
	public int nbOfCommands;
	public List<string> allWordsFound;
	public List<string>	allCommandsFound;
}
