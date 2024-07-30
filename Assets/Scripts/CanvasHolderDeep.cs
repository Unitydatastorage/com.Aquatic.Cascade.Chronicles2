using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderDeep : MonoBehaviour
{
    public Canvas loadingCanvasDeep;
    public Canvas pressOkCanvasDeep;
    public Canvas menuCanvasDeep;
    public Canvas settingsCanvasDeep;
    public Canvas policyCanvasDeep;
    public Canvas gameCanvasDeep;
    public Canvas winCanvasDeep;
    public Canvas levelChoiceCanvasDeep;


    float sliderValueDeep = 0;

    public Slider sliderDeep;


    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }


    public bool activeDeep = true;

    Timer tDeep;

    public Stack<string> currentStackDeep;


    void Start()
    {
        CoinFlipDeep();
        pressOkCanvasDeep.enabled = false;
        menuCanvasDeep.enabled = false; 
        settingsCanvasDeep.enabled = false;
        policyCanvasDeep.enabled = false;
        CoinFlipDeep();
        gameCanvasDeep.enabled = false;
        winCanvasDeep.enabled = false;
        levelChoiceCanvasDeep.enabled = false;
        currentStackDeep = new Stack<string>();
        CoinFlipDeep();
        HideTimerDeep();
    }

 
    public void EndLoadDeep()
    {
        CoinFlipDeep();
        loadingCanvasDeep.enabled = false;
        pressOkCanvasDeep.enabled = true;
        CoinFlipDeep();
    }


    public void MoveToOKDeep()
    {
        CoinFlipDeep();
        if (activeDeep)
        {
            CoinFlipDeep();
            pressOkCanvasDeep.enabled = true;
            policyCanvasDeep.enabled = false;
        }
        else MoveBackDeep();
    }

    public void HideTimerDeep()
    {
        CoinFlipDeep();
        tDeep = new Timer(2000);
        tDeep.AutoReset = false;
        CoinFlipDeep();
        tDeep.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tDeep.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
       
        try
        {
            CoinFlipDeep();
            EndLoadDeep();
        }
        finally
        {
            CoinFlipDeep();
            tDeep.Enabled = false;
        }
    }

    public void MoveBackDeep()
    {
        currentStackDeep.Pop();
        CoinFlipDeep();
        MoveDeep(currentStackDeep.Peek(), true);
    }
    public void MoveDeep(string destinationDeep, bool backmoveDeep = false)
    {
        CoinFlipDeep();
        pressOkCanvasDeep.enabled = false;
        menuCanvasDeep.enabled = false;
        settingsCanvasDeep.enabled = false;
        policyCanvasDeep.enabled = false;
        gameCanvasDeep.enabled = false;
        CoinFlipDeep();
        winCanvasDeep.enabled = false;
        levelChoiceCanvasDeep.enabled = false;

        if (destinationDeep == "winDeep")
        {
            CoinFlipDeep();
            winCanvasDeep.enabled = true;
            winCanvasDeep.GetComponent<WinScriptDeep>().WinScreenDeep();
            backmoveDeep = true;
        }


        CoinFlipDeep();

        if (destinationDeep == "menuDeep")
        {
            menuCanvasDeep.enabled = true;
            activeDeep = false;
        }
        else if (destinationDeep == "settingsDeep")
        {
            settingsCanvasDeep.enabled = true;
        }    
        else if (destinationDeep == "policyDeep")
        {
            CoinFlipDeep();
            policyCanvasDeep.enabled = true;
        }
        else if (destinationDeep == "gameDeep")
        {
            gameCanvasDeep.enabled = true;
            if (!backmoveDeep) gameCanvasDeep.GetComponent<GameLogicDeep>().GameStartDeep();
        }
        else if (destinationDeep == "levelDeep")
        {
            CoinFlipDeep();
            levelChoiceCanvasDeep.enabled = true;
        }
        CoinFlipDeep();
        if (!backmoveDeep) { currentStackDeep.Push(destinationDeep); }
        
     
    }

    void Update()
    {

        if (loadingCanvasDeep.enabled)
        {
            CoinFlipDeep();
            float time = sliderValueDeep + Time.time;
            if (time < 101)
            {
                CoinFlipDeep();
                sliderDeep.value = time;
            }
        }


        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackDeep.Count == 1)
                    {
                        CoinFlipDeep();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackDeep();
                    }

                }
            }
            catch (Exception eDeep)
            {

            }
        }
    }


}
