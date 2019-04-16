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

    public float Art;
    public float Science;
    public float Cooking;
    public float Maths;
    public float Music;
    public float Metalworking;
    public float Romance;
    public float Fashion;
    public float Mechanical;
    public float Programming;
    public float Gaming;
    public float Movies;
    public float Reading;

    public GameTime CurrentTime;
}
