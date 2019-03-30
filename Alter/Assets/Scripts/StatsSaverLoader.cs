using System.IO;
using UnityEngine;

public class StatsSaverLoader : MonoBehaviour
{
    public static StatsSaverLoader Instance = null;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's already a StatsSaverLoader in the scene. Destroying this instance.");
            Destroy(this);
        }
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save(CharacterStats stats, uint playerID)
    {
        string jsonString = JsonUtility.ToJson(stats);

        using (StreamWriter streamWriter = File.CreateText("SaveFile" + playerID + ".json"))
        {
            streamWriter.Write(jsonString);
        }
    }

    public CharacterStats Load(uint playerID)
    {
        using (StreamReader streamReader = File.OpenText("SaveFile" + playerID + ".json"))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<CharacterStats>(jsonString);
        }
    }
}
