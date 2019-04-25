using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueChoice
{
	public string dialogue;
	public string opt1;
	public string opt2;
	public int path1;
	public int path2;
	public int friendMod1;
	public int friendMod2;
	public int relMod1;
	public int relMod2;
	
	public static DialogueChoice GetFromJson(string json)
	{
		return JsonUtility.FromJson<DialogueChoice>(json);
	}
	
	public static string SaveToJson(DialogueChoice data)
	{
		return JsonUtility.ToJson(data, true);
	}
}
