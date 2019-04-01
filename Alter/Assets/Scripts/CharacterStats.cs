using System;

[Serializable]
public class GameTime
{
    public uint Day;
    public uint Hour;

    public bool ProgressHour(uint hour)
    {
        Hour += hour;
        if (Hour < 24) return false;
        Hour -= 24;
        Day += 1;
        return true;
    }
}


[Serializable]
public class CharacterStats
{
    public float PhysicalHealth;
    public float Anxiety;
    public float Happiness;
    public float Stress;
    public float Bladder;
    public float Sleep;
    public float Thirst;
    public float Hunger;
    public float Cleanliness;
    public GameTime CurrentTime;
}
