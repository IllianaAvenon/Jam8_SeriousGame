using UnityEngine;

public class SaveLoadTester : MonoBehaviour
{
    public uint PlayerID;
    public CharacterStats Stats;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Save()
    {
        StatsSaverLoader.Instance.Save(Stats, PlayerID);
    }

    public void Load()
    {
        Stats = StatsSaverLoader.Instance.Load(PlayerID);
    }
}
