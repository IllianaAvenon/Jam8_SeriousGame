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
        Stats.CurrentTime.ProgressHour(1);
        if (Stats.CurrentTime.Hour == 0)
            movementController.ResetPosition();
    }
}
