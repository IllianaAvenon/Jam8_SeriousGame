using UnityEngine;

public class SaveLoadTester : MonoBehaviour
{
    public uint PlayerID;
    public CharacterStats Stats;

    private MovementController movementController;
    

    void Start()
    {
        movementController = GetComponent<MovementController>();
        if (movementController == null)
        {
            Debug.LogError("Attach MovementController Script with This Script!");
        }
    }

     public void Save()
    {
        StatsSaverLoader.Instance.Save(Stats, PlayerID);
    }

    public void Load()
    {
        Stats = StatsSaverLoader.Instance.Load(PlayerID);
    }

    public void ProgressByOneHour()
    {
        if (Stats.CurrentTime.ProgressHour(1))
            movementController.ResetPosition();
    }

    public void UpdateGoal(int goal, int increm)
    {
        switch(goal)
        {
            case 0: Stats.Art += increm; break;
            case 1: Stats.Science += increm; break;
            case 2: Stats.Cooking += increm; break;
            case 3: Stats.Maths += increm; break;
            case 4: Stats.Music += increm; break;
            case 5: Stats.Metalworking += increm; break;
            case 6: Stats.Romance += increm; break;
            case 7: Stats.Fashion += increm; break;
            case 8: Stats.Mechanical += increm; break;
            case 9: Stats.Programming += increm; break;
            case 10: Stats.Gaming += increm; break;
            case 11: Stats.Movies += increm; break;
            case 12: Stats.Reading += increm; break;
        }

    }
}
