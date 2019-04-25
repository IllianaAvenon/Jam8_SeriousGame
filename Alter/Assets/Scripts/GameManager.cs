using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

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
    public ParticleSystem clean;
    public ParticleSystem food;
    public ParticleSystem thirst;
    public ParticleSystem goals;
    public ParticleSystem sleep;
    private bool goalPass;

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
        if (stressTest > 4.0f)
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
            currentStats.StatDecrement();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            fade.SetTrigger("enter");
            currentStats.Stats = StatsSaverLoader.Instance.Load(currentStats.PlayerID);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
            {
                Debug.Log(hit.collider);

                if (Vector3.Distance(physicalPlayer.transform.position, hit.transform.position) <= 2.5f)
                {
                    Debug.Log("Actual hit");
                    OnInteraction(hit.collider.gameObject);
                }
            }
        }
    }

      public void OnInteraction(GameObject item)
    {
        if(item.name == "door")
        {
            if(SceneManager.GetActiveScene().name == "Main")
            {
                SceneManager.LoadScene("Outside");
            }
            else
            {
                SceneManager.LoadScene("Main");
            }
        }
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


       for(int i = 0; i < goalsList.Count; i++)
        {
            if(goalsList[i] != 0)
            {
                currentStats.SetStatIncrement(i, goalsList[i]);
                goalPass = true;
            }

            if(goalPass)
            {
                goals.transform.position = physicalPlayer.transform.position; goals.Play(); goalPass = false;
            }
        }

        //Sort out Effects of Objects on Physical State
        for(int i = 0; i < statsList.Count; i++ )
        {
            if (statsList[i] != 0)
            {
                switch(i)
                {
                    case 0: currentStats.Stats.Bladder += (float)statsList[i] * BaseModifier; break;
                    case 1: currentStats.Stats.Sleep += (float)statsList[i] * BaseModifier; sleep.transform.position = physicalPlayer.transform.position; sleep.Play(); break;
                    case 2: currentStats.Stats.Thirst += (float)statsList[i] * BaseModifier; thirst.transform.position = physicalPlayer.transform.position; thirst.Play(); break;
                    case 3: currentStats.Stats.Hunger += (float)statsList[i] * BaseModifier; food.transform.position = physicalPlayer.transform.position; food.Play(); break;
                    case 4: currentStats.Stats.Cleanliness += (float)statsList[i] * BaseModifier; clean.transform.position = physicalPlayer.transform.position; clean.Play(); break;

                }
            }

        }
    }
}
