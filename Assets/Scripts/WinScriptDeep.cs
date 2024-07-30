using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinScriptDeep : MonoBehaviour
{
    public Text ScoreTxtDeep;


    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }

    public void WinScreenDeep()
    {
        CoinFlipDeep();

        CoinFlipDeep();
        ScoreTxtDeep.text = GameObject.Find("ScoreTextDeep").GetComponent<Text>().text;
        GameObject.Find("LevelChoiceCanvasDeep").GetComponent<LevelActivatorDeep>().ActivateButtonsDeep();
        CoinFlipDeep();
    }

}
