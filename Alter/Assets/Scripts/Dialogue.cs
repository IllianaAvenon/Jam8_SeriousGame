using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
	public List<DialogueChoice> choice;
	
	public static Dialogue GetFromJson(string json)
	{
		return JsonUtility.FromJson<Dialogue>(json);
	}
	
	public static string SaveToJson(Dialogue data)
	{
		return JsonUtility.ToJson(data, true);
	}
}
