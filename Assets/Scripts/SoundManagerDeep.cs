using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerDeep : MonoBehaviour
{
    public AudioSource themeDeep;
    public AudioSource pingDeep;
    public AudioSource clickDeep;
  

    public bool soundIsOnDeep = true;

    public bool musicIsOnDeep = true;
    public bool changedDeep = false;


    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }
    void Start()
    {
        CoinFlipDeep();
        CoinFlipDeep();
        themeDeep.Play();
    }

    public void PlayPingDeep()
    {
        CoinFlipDeep();
        if (soundIsOnDeep) { pingDeep.Play(); }
        
    }

    public void PlayClickDeep()
    {
        CoinFlipDeep();
        if (soundIsOnDeep) { clickDeep.Play();
            CoinFlipDeep();
        }
       
    }



    void Update()
    {
        if (!musicIsOnDeep)
        {
            themeDeep.volume = 0f;
            CoinFlipDeep();
        }
        else themeDeep.volume = 1f;

        if (!themeDeep.isPlaying)
        {
            if(musicIsOnDeep) {
                CoinFlipDeep(); 
                themeDeep.Play(); }
            
        }
    }


}
