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

    public Image[] goalsImages;

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

    Vector3[] goalsStatScales;

    //local scale
    Vector3 TempLocalScale;


    // Use this for initialization
    void Start () {

        goalsStatScales = new Vector3[13];
        TempLocalScale.x = 1.0f;
        TempLocalScale.y = 0.2024923f;
        TempLocalScale.z = 0.92838f;

        //set based on camera view
        //namePos = Camera.main.transform.position;

       // namePos.x = XAxisCount + 0.1f;
       // namePos.y = YAxisCount + 0.5f;

        // Assign positions one below the other
        //BladderStatPos = namePos;
        //namePos.y = namePos.y - 50.0f;
        //SleepStatPos =namePos;
        //namePos.y = namePos.y - 50.0f;
        //HungerStatPos = namePos;
        //namePos.y = namePos.y - 50.0f;
        //ThirstStatPos = namePos;
        //namePos.y = namePos.y - 50.0f;
        //CleanlinessStatPos = namePos;

        //Set positions
        //Bladder.transform.position = BladderStatPos;
        //Sleep.transform.position = SleepStatPos;
        //Hunger.transform.position = HungerStatPos;
        //Thirst.transform.position = ThirstStatPos;
        //Cleanliness.transform.position = CleanlinessStatPos;

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

        for (int i = 0; i < goalsImages.Length; ++i)
        {
            goalsStatScales[i] = TempLocalScale;
            goalsImages[i].transform.localScale = goalsStatScales[i];
        }

        gameManager = gameManager.GetComponent<GameManager>();
    }

    //Functions takes two arguments- 1) Pass the string tag ie.e the name of the stat. 
    //2) Affected stat amount. Pass value from 1-100 as int. As the function is based on scale, I convert it to 0-1 range in the function.  
    public void SetStatAmount(string tag, float AmountInBar)
    {
        // I don't think this actually happens?

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

        Debug.Log(gameManager.currentStats.Stats.Cleanliness);

        // Change the scale of the stats from function SetStatAmount().
        BladderStatScale.x = Mathf.Clamp(gameManager.currentStats.Stats.Bladder / 100, 0.0f, 1.0f);
        SleepStatScale.x = Mathf.Clamp(gameManager.currentStats.Stats.Sleep / 100, 0.0f, 1.0f);
        ThirstStatScale.x = Mathf.Clamp(gameManager.currentStats.Stats.Thirst / 100, 0.0f, 1.0f);
        HungerStatScale.x = Mathf.Clamp(gameManager.currentStats.Stats.Hunger / 100, 0.0f, 1.0f);
        CleanlinessStatScale.x = Mathf.Clamp(gameManager.currentStats.Stats.Cleanliness / 100, 0.0f, 1.0f);

        goalsStatScales[0].x =  Mathf.Clamp(gameManager.currentStats.Stats.Art / 100, 0.0f, 1.0f);
        goalsStatScales[1].x =  Mathf.Clamp(gameManager.currentStats.Stats.Science / 100, 0.0f, 1.0f);
        goalsStatScales[2].x =  Mathf.Clamp(gameManager.currentStats.Stats.Cooking / 100, 0.0f, 1.0f);
        goalsStatScales[3].x =  Mathf.Clamp(gameManager.currentStats.Stats.Maths / 100, 0.0f, 1.0f);
        goalsStatScales[4].x =  Mathf.Clamp(gameManager.currentStats.Stats.Music / 100, 0.0f, 1.0f);
        goalsStatScales[5].x =  Mathf.Clamp(gameManager.currentStats.Stats.Metalworking / 100, 0.0f, 1.0f);
        goalsStatScales[6].x =  Mathf.Clamp(gameManager.currentStats.Stats.Romance / 100, 0.0f, 1.0f);
        goalsStatScales[7].x =  Mathf.Clamp(gameManager.currentStats.Stats.Fashion / 100, 0.0f, 1.0f);
        goalsStatScales[8].x =  Mathf.Clamp(gameManager.currentStats.Stats.Mechanical / 100, 0.0f, 1.0f);
        goalsStatScales[9].x =  Mathf.Clamp(gameManager.currentStats.Stats.Programming / 100, 0.0f, 1.0f);
        goalsStatScales[10].x = Mathf.Clamp(gameManager.currentStats.Stats.Gaming / 100, 0.0f, 1.0f);
        goalsStatScales[11].x = Mathf.Clamp(gameManager.currentStats.Stats.Movies / 100, 0.0f, 1.0f);
        goalsStatScales[12].x = Mathf.Clamp(gameManager.currentStats.Stats.Reading / 100, 0.0f, 1.0f);

        Bladder.transform.localScale = BladderStatScale;
        Sleep.transform.localScale = SleepStatScale;
        Hunger.transform.localScale = HungerStatScale;
        Thirst.transform.localScale = ThirstStatScale;
        Cleanliness.transform.localScale = CleanlinessStatScale;

        for (int i = 0; i < goalsImages.Length; ++i)
        {
            goalsImages[i].transform.localScale = goalsStatScales[i];
        }
    }
}
