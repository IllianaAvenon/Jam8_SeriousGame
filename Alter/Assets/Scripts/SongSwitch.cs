using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSwitch : MonoBehaviour {

    public AudioSource source;
    public AudioClip twinkle;
    public AudioClip spacePit;
    public AudioClip happy;
    public AudioClip marimba;
    public GameObject panel;


    public void SwitchTwinkle()
    {
        source.clip = twinkle;
        source.Play();
        panel.SetActive(false);
    }

    public void SwitchPit()
    {
        source.clip = spacePit;
        source.Play();
        panel.SetActive(false);
    }

    public void SwitchHappy()
    {
        source.clip = happy;
        source.Play();
        panel.SetActive(false);
    }

    public void SwitchBoy()
    {
        source.clip = marimba;
        source.Play();
        panel.SetActive(false);
    }


}
