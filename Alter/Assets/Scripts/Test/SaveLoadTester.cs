using UnityEngine;

public class SaveLoadTester : MonoBehaviour
{
    public uint PlayerID;
    public CharacterStats Stats;

    private MovementController movementController;
    // Use this for initialization
    void Start()
    {
        movementController = GetComponent<MovementController>();
        if (movementController == null)
        {
            Debug.LogError("Attach MovementController Script with This Script!");
        }
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

    public void ProgressByOneHour()
    {
        if (Stats.CurrentTime.ProgressHour(1))
            movementController.ResetPosition();
    }

    public void SetStatIncrement(int index, int control)
    {
        switch (index)
        {
            case 0: Stats.Art+= control; break;
            case 1: Stats.Science+= control; break;
            case 2: Stats.Cooking+= control; break;
            case 3: Stats.Maths+= control; break;
            case 4: Stats.Music+= control; break;
            case 5: Stats.Metalworking+= control; break;
            case 6: Stats.Romance+= control; break;
            case 7: Stats.Fashion+= control; break;
            case 8: Stats.Mechanical+= control; break;
            case 9: Stats.Programming+= control; break;
            case 10: Stats.Gaming+= control; break;
            case 11: Stats.Movies+= control; break;
            case 12: Stats.Reading+= control; break;
        }
    }

    public void StatDecrement()
    {
            Stats.Art--; 
            Stats.Science--; 
            Stats.Cooking--; 
            Stats.Maths--; 
            Stats.Music--; 
            Stats.Metalworking--; 
            Stats.Romance--; 
            Stats.Fashion--; 
            Stats.Mechanical--; 
            Stats.Programming--; 
             Stats.Gaming--; 
             Stats.Movies--; 
             Stats.Reading--; 
    }
}
