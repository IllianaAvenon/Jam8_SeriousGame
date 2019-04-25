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
            case 0: Stats.Art = Mathf.Min(Stats.Art + control, 100); break;
            case 1: Stats.Science = Mathf.Min(Stats.Science + control, 100); break;
            case 2: Stats.Cooking = Mathf.Min(Stats.Science + control, 100); break;
            case 3: Stats.Maths = Mathf.Min(Stats.Maths + control, 100); break;
            case 4: Stats.Music = Mathf.Min(Stats.Music + control, 100); break;
            case 5: Stats.Metalworking = Mathf.Min(Stats.Metalworking + control, 100); break;
            case 6: Stats.Romance = Mathf.Min(Stats.Romance + control, 100); break;
            case 7: Stats.Fashion = Mathf.Min(Stats.Fashion + control, 100); break;
            case 8: Stats.Mechanical = Mathf.Min(Stats.Mechanical + control, 100); break;
            case 9: Stats.Programming = Mathf.Min(Stats.Programming + control, 100); break;
            case 10: Stats.Gaming = Mathf.Min(Stats.Gaming + control, 100); break;
            case 11: Stats.Movies = Mathf.Min(Stats.Movies + control, 100); break;
            case 12: Stats.Reading = Mathf.Min(Stats.Reading + control, 100); break;
        }
    }

    public void StatDecrement()
    {
            Stats.Art = Mathf.Max(Stats.Art - 1, 0); 
            Stats.Science = Mathf.Max(Stats.Science - 1, 0); 
            Stats.Cooking = Mathf.Max(Stats.Cooking - 1, 0); 
            Stats.Maths = Mathf.Max(Stats.Maths - 1, 0); 
            Stats.Music = Mathf.Max(Stats.Music - 1, 0); 
            Stats.Metalworking = Mathf.Max(Stats.Metalworking - 1, 0); 
            Stats.Romance = Mathf.Max(Stats.Romance - 1, 0); 
            Stats.Fashion = Mathf.Max(Stats.Fashion - 1, 0); 
            Stats.Mechanical = Mathf.Max(Stats.Mechanical - 1, 0); 
            Stats.Programming = Mathf.Max(Stats.Programming - 1, 0); 
			Stats.Gaming = Mathf.Max(Stats.Gaming - 1, 0); 
            Stats.Movies = Mathf.Max(Stats.Movies - 1, 0); 
            Stats.Reading = Mathf.Max(Stats.Reading - 1, 0); 
    }
}
