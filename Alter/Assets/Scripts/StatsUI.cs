using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    //Set Stat Images
    public Image Bladder;
    public Image Sleep;
    public Image Hunger;
    public Image Thirst;
    public Image Cleanliness;
    public GameManager gameManager;

    //Set Stat Positions according to camera
    float YAxisCount = 100.0f*4;
    float XAxisCount = 100.0f;

    //Stat Position and scale vectors
    Vector3 BladderStatPos;
    Vector3 BladderStatScale;

    Vector3 SleepStatPos;
    Vector3 SleepStatScale;

    Vector3 ThirstStatPos;
    Vector3 ThirstStatScale;

    Vector3 HungerStatPos;
    Vector3 HungerStatScale;

    Vector3 CleanlinessStatPos;
    Vector3 CleanlinessStatScale;

    //local scale
    Vector3 TempLocalScale;


    // Use this for initialization
    void Start () {
   
        Vector3 namePos;
        TempLocalScale.x = 1.0f;
        TempLocalScale.y = 0.2024923f;
        TempLocalScale.z = 0.92838f;

        //set based on camera view
        namePos = Camera.main.transform.position;

        namePos.x = XAxisCount + 0.1f;
        namePos.y = YAxisCount + 0.5f;

        // Assign positions one below the other
        BladderStatPos = namePos;
        namePos.y = namePos.y - 50.0f;
        SleepStatPos =namePos;
        namePos.y = namePos.y - 50.0f;
        HungerStatPos = namePos;
        namePos.y = namePos.y - 50.0f;
        ThirstStatPos = namePos;
        namePos.y = namePos.y - 50.0f;
        CleanlinessStatPos = namePos;

        //Set positions
        Bladder.transform.position = BladderStatPos;
        Sleep.transform.position = SleepStatPos;
        Hunger.transform.position = HungerStatPos;
        Thirst.transform.position = ThirstStatPos;
        Cleanliness.transform.position = CleanlinessStatPos;

        //Assign scales
        BladderStatScale = TempLocalScale;
        SleepStatScale = TempLocalScale;
        HungerStatScale = TempLocalScale;
        ThirstStatScale = TempLocalScale;
        CleanlinessStatScale = TempLocalScale;

        //Set Scales
        Bladder.transform.localScale= BladderStatScale;
        Sleep.transform.localScale = SleepStatScale;
        Hunger.transform.localScale= HungerStatScale;
        Thirst.transform.localScale = ThirstStatScale;
        Cleanliness.transform.localScale = CleanlinessStatScale;

        gameManager = gameManager.GetComponent<GameManager>();
    }

    //Functions takes two arguments- 1) Pass the string tag ie.e the name of the stat. 
    //2) Affected stat amount. Pass value from 1-100 as int. As the function is based on scale, I convert it to 0-1 range in the function.  
    public void SetStatAmount(string tag, float AmountInBar)
    {
        if(tag=="Bladder")
        {
            BladderStatScale.x = (float)(AmountInBar) / 100;
        }
        else if(tag=="Sleep")
        {
            SleepStatScale.x=(float)(AmountInBar)/100;
        }
        else if (tag == "Thirst")
        {
            ThirstStatScale.x= (float)(AmountInBar) /100;
        }
        else if (tag == "Hunger")
        {
            HungerStatScale.x = (float)(AmountInBar) /100;
        }
        else if (tag == "Cleanliness")
        {
            CleanlinessStatScale.x = (float)(AmountInBar) /100;
        }
    }


	// Update is called once per frame
	void Update () {

        // Change the scale of the stats from function SetStatAmount().
        BladderStatScale.x = Mathf.Clamp(gameManager.currentStats.Bladder / 10, 0.0f, 1.0f);
        SleepStatScale.x = gameManager.currentStats.Sleep;
        ThirstStatScale.x = gameManager.currentStats.Thirst / 10.0f;
        HungerStatScale.x = gameManager.currentStats.Hunger / 10.0f;
        CleanlinessStatScale.x = gameManager.currentStats.Cleanliness / 10.0f;


        Bladder.transform.localScale = BladderStatScale;
        Sleep.transform.localScale = SleepStatScale;
        Hunger.transform.localScale = HungerStatScale;
        Thirst.transform.localScale = ThirstStatScale;
        Cleanliness.transform.localScale = CleanlinessStatScale;

    }
}
