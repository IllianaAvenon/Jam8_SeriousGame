using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Item : MonoBehaviour {

    public Transform itemTransform;
    
    //Trait tags define positive and negative influences towards goals based on their typing
    public int Art;
    public int Science;
    public int Cooking;
    public int Maths;
    public int Music;
    public int Metalworking;
    public int Romance;
    public int Fashion;
    public int Mechanical;
    public int Programming;
    public int Gaming;
    public int Movies;
    public int Reading;

    //Attribute Tags represent affects on physical stats (ie the bathtub buffs cleanliness)
    public int Bladder;
    public int Sleep;
    public int Thirst;
    public int Hunger;
    public int Cleanliness;

    public int[] GetTags()
    {
        int[] tags = { Art, Science, Cooking, Maths, Music, Metalworking, Romance,
            Fashion, Mechanical, Programming, Gaming, Movies, Reading, Bladder, Sleep,
        Thirst, Hunger, Cleanliness};
        return tags;
    }
}
