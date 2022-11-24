using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
	public int nbOfSheet;
	public int nbOfWrite;
	public int nbOfWords;
	public int nbOfCommands;
	public List<string> allWordsFound;
	public List<string>	allCommandsFound;
}
