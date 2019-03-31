using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject physicalPlayer;
    public GameObject currentAlter;
    public CharacterStats currentStats;
    public Goals currentGoals;
    public string[] GoalsConversion = { "Art", "Science", "Cooking", "Maths", "Music", "Metalworking", "Romance", "Fashion", "Mechanical", "Programming", "Gaming", "Movies", "Reading" };
    public string[] StatsConversion = { "Bladder", "Sleep", "Thirst", "Hunger", "Cleanliness" };
    public float BaseModifier = 0.3f;
    public float stressTest = 0.0f;

    private void Start()
    {
        currentStats = physicalPlayer.GetComponent<CharacterStats>();
        currentGoals = currentAlter.GetComponent<Goals>();
    }

    private void Update()
    {
        if (currentStats.Anxiety > 85 || currentStats.Stress > 85 || currentStats.Anxiety + currentStats.Stress > 68)
        {
            ///TODO : Switching
        }

        stressTest += Time.deltaTime;
        if (stressTest > 300.0f)
        {
            if (currentStats.Bladder < 15 || currentStats.Sleep < 15 || currentStats.Thirst < 15 || currentStats.Hunger < 15 || currentStats.Cleanliness < 15 || currentStats.Bladder + currentStats.Sleep + currentStats.Thirst + currentStats.Hunger + currentStats.Cleanliness < 80)
            {
                currentStats.Stress += BaseModifier;
            }
            stressTest = 0.0f;
            currentStats.Bladder -= 1;
            currentStats.Sleep -= 1;
            currentStats.Hunger -= 1;
            currentStats.Thirst -= 1;
            currentStats.Cleanliness -= 1;
        }
        
    }

    public void OnInteraction(GameObject item)
    {
        Item interactedItem = item.GetComponent<Item>();
        int[] Influencers = interactedItem.GetTags();
        int[] goalsList = { };
        int[] statsList = { };

        for (int i = 0; i < Influencers.Length - 5; i++)
        {
            goalsList[i] = Influencers[i];
        }

        for (int i = Influencers.Length - 5; i < Influencers.Length; i++)
        {
            statsList[i] = Influencers[i];
        }





        //Sort out effects of objects on Mental State
        int index = 0;
        foreach (int tag in goalsList)
        {
            if (tag != 0)
            {
                if (currentGoals.listOfGoals.Contains(GoalsConversion[index]))
                {
                    currentStats.Anxiety -= (float)tag * BaseModifier;
                    currentStats.Stress -= (float)tag * BaseModifier;
                    currentStats.Happiness += (float)tag * BaseModifier;
                }

                else
                {
                    currentStats.Anxiety += (float)tag * BaseModifier;
                    currentStats.Stress += (float)tag * BaseModifier;
                    currentStats.Happiness -= (float)tag * BaseModifier;
                }
            }

            index++;
        }
        index = 0;

        //Sort out Effects of Objects on Physical State
        for(int i = 0; i < statsList.Length; i++ )
        {
            if (statsList[i] != 0)
            {
                switch(i)
                {
                    case 0: currentStats.Bladder += (float)statsList[i] * BaseModifier; break;
                    case 1: currentStats.Bladder += (float)statsList[i] * BaseModifier; break;
                    case 2: currentStats.Bladder += (float)statsList[i] * BaseModifier; break;
                    case 3: currentStats.Bladder += (float)statsList[i] * BaseModifier; break;
                    case 4: currentStats.Bladder += (float)statsList[i] * BaseModifier; break;

                }
            }

        }
    }
}
