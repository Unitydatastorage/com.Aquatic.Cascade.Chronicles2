using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasDeep : MonoBehaviour
{

    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }


    public void JumpDeep(string destinationDeep)
    {
        CoinFlipDeep();
        GameObject.Find("MainCameraDeep").GetComponent<SoundManagerDeep>().PlayClickDeep();
        CoinFlipDeep();
        GameObject.Find("MainCameraDeep").GetComponent<CanvasHolderDeep>().MoveDeep(destinationDeep,false);
    }


    public void JumpDeepLevel(int levelDeep)
    {
        CoinFlipDeep();
        GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().pickedLevelDeep = levelDeep;
        JumpDeep("gameDeep");
    }


    public void JumpBackDeep()
    {
        CoinFlipDeep();
        GameObject.Find("MainCameraDeep").GetComponent<SoundManagerDeep>().PlayClickDeep();
        GameObject.Find("MainCameraDeep").GetComponent<CanvasHolderDeep>().MoveBackDeep();
    }

    public void JumpOKDeep()
    {
        CoinFlipDeep();
        GameObject.Find("MainCameraDeep").GetComponent<SoundManagerDeep>().PlayClickDeep();
        GameObject.Find("MainCameraDeep").GetComponent<CanvasHolderDeep>().MoveToOKDeep();
    }

    public void CloseDeep()
    {
        CoinFlipDeep();
        CoinFlipDeep();
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }
}
