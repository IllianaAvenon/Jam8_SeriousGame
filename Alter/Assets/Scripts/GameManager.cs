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
            if (currentStats.Stats.Bladder < 20 || currentStats.Stats.Sleep < 20 || currentStats.Stats.Thirst < 20 || currentStats.Stats.Hunger < 20 || currentStats.Stats.Cleanliness < 20 || currentStats.Stats.Bladder + currentStats.Stats.Sleep + currentStats.Stats.Thirst + currentStats.Stats.Hunger + currentStats.Stats.Cleanliness < 200)
            {
                currentStats.Stats.Stress += BaseModifier;
            }
            stressTest = 0.0f;
            currentStats.Stats.Bladder = Mathf.Max(currentStats.Stats.Bladder - 1, 0);
            currentStats.Stats.Sleep = Mathf.Max(currentStats.Stats.Sleep - 1, 0);
            currentStats.Stats.Hunger = Mathf.Max(currentStats.Stats.Hunger- 1, 0);
            currentStats.Stats.Thirst = Mathf.Max(currentStats.Stats.Thirst - 1, 0);
            currentStats.Stats.Cleanliness = Mathf.Max(currentStats.Stats.Cleanliness - 1, 0);
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
                OnInteraction(hit.collider.gameObject);
            }
        }
    }

      public void OnInteraction(GameObject item)
    {
		if(item.tag == "NPC")
		{
			item.GetComponent<NPC>().Interact(physicalPlayer);
			return;
		}
		
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
                    case 0: currentStats.Stats.Bladder = Mathf.Min(currentStats.Stats.Bladder + (float)statsList[i] * BaseModifier, 100); break;
                    case 1: currentStats.Stats.Sleep = Mathf.Min(currentStats.Stats.Sleep+ (float)statsList[i] * BaseModifier, 100); sleep.transform.position = physicalPlayer.transform.position; sleep.Play(); break;
                    case 2: currentStats.Stats.Thirst = Mathf.Min(currentStats.Stats.Thirst+ (float)statsList[i] * BaseModifier, 100); thirst.transform.position = physicalPlayer.transform.position; thirst.Play(); break;
                    case 3: currentStats.Stats.Hunger = Mathf.Min(currentStats.Stats.Hunger+ (float)statsList[i] * BaseModifier, 100); food.transform.position = physicalPlayer.transform.position; food.Play(); break;
                    case 4: currentStats.Stats.Cleanliness = Mathf.Min(currentStats.Stats.Cleanliness + (float)statsList[i] * BaseModifier, 100); clean.transform.position = physicalPlayer.transform.position; clean.Play(); break;

                }
            }

        }
    }
}
