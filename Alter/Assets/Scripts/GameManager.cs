using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject physicalPlayer;
    public GameObject currentAlter;
    public SaveLoadTester currentStats;
    public Goals currentGoals;
    public string[] GoalsConversion = { "Art", "Science", "Cooking", "Maths", "Music", "Metalworking", "Romance", "Fashion", "Mechanical", "Programming", "Gaming", "Movies", "Reading" };
    public string[] StatsConversion = { "Bladder", "Sleep", "Thirst", "Hunger", "Cleanliness" };
    public float BaseModifier = 0.3f;
    public float stressTest = 0.0f;
    public Animator fade;

    private void Start()
    {
        currentStats = physicalPlayer.GetComponent<SaveLoadTester>();
    }

    private void Update()
    {
        if (currentStats.Stats.Anxiety > 85 || currentStats.Stats.Stress > 85 || currentStats.Stats.Anxiety + currentStats.Stats.Stress > 68)
        {
            ///TODO : Switching
        }

        stressTest += Time.deltaTime;
        if (stressTest > 100.0f)
        {
            if (currentStats.Stats.Bladder < 15 || currentStats.Stats.Sleep < 15 || currentStats.Stats.Thirst < 15 || currentStats.Stats.Hunger < 15 || currentStats.Stats.Cleanliness < 15 || currentStats.Stats.Bladder + currentStats.Stats.Sleep + currentStats.Stats.Thirst + currentStats.Stats.Hunger + currentStats.Stats.Cleanliness < 80)
            {
                currentStats.Stats.Stress += BaseModifier;
            }
            stressTest = 0.0f;
            currentStats.Stats.Bladder -= 1;
            currentStats.Stats.Sleep -= 1;
            currentStats.Stats.Hunger -= 1;
            currentStats.Stats.Thirst -= 1;
            currentStats.Stats.Cleanliness -= 1;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            fade.SetTrigger("enter");
            currentStats.Stats = StatsSaverLoader.Instance.Load(++currentStats.PlayerID);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
            {
                Debug.Log(hit.collider);
                OnInteraction(hit.collider.gameObject);
            }
        }
    }

    public void OnInteraction(GameObject item)
    {

        Item interactedItem = item.GetComponent<Item>();
        if (interactedItem == null) return;
        int[] Influencers = interactedItem.GetTags();
        List<int> goalsList = new List<int>();
        List<int> statsList = new List<int>();

        for (int i = 0; i < Influencers.Length - 5; i++)
        {
            goalsList.Add(Influencers[i]);
        }

        for (int i = Influencers.Length - 5; i < Influencers.Length; i++)
        {
            statsList.Add(Influencers[i]);
        }

        //Sort out effects of objects on Mental State
        int index = 0;
        foreach (int tag in goalsList)
        {
            if (tag != 0)
            {

                currentStats.Stats.Anxiety -= (float)tag * BaseModifier;
                currentStats.Stats.Stress -= (float)tag * BaseModifier;
                currentStats.Stats.Happiness += (float)tag * BaseModifier;
                currentStats.UpdateGoal(index, (int)((float)tag * BaseModifier));

            }

            index++;
        }
        index = 0;

        //Sort out Effects of Objects on Physical State
        for (int i = 0; i < statsList.Count; i++)
        {
            if (statsList[i] != 0)
            {
                switch (i)
                {
                    case 0: currentStats.Stats.Bladder += (float)statsList[i] * BaseModifier; break;
                    case 1: currentStats.Stats.Sleep += (float)statsList[i] * BaseModifier; break;
                    case 2: currentStats.Stats.Thirst += (float)statsList[i] * BaseModifier; break;
                    case 3: currentStats.Stats.Hunger += (float)statsList[i] * BaseModifier; break;
                    case 4: currentStats.Stats.Cleanliness += (float)statsList[i] * BaseModifier; break;

                }
            }
        }
    }
}
