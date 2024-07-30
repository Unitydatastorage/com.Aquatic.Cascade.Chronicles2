using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonsDeep : MonoBehaviour
{
    public Sprite onStateDeep;
    public Sprite offStateDeep;

    public Button buttonDeep;


    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 15);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }


    public bool isSound;
    
    public bool activeDeep=true;

    public void PressDeep()
    {
        activeDeep = !activeDeep;

        CoinFlipDeep();
        if (activeDeep)
        {
            CoinFlipDeep();
            buttonDeep.GetComponent<Image>().sprite=onStateDeep;     
        }
        else
        {
            CoinFlipDeep();
            buttonDeep.GetComponent<Image>().sprite = offStateDeep;
        }

        if (isSound) GameObject.Find("MainCameraDeep").GetComponent<SoundManagerDeep>().soundIsOnDeep = activeDeep;
        else GameObject.Find("MainCameraDeep").GetComponent<SoundManagerDeep>().musicIsOnDeep = activeDeep;
        CoinFlipDeep();
    }


}

