using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LevelActivatorDeep : MonoBehaviour
{



    public int currentLevelDeep = -1;


    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }

    public void ActivateButtonsDeep()
    {
        currentLevelDeep++;
        int tempDeep = currentLevelDeep;
        CoinFlipDeep();
        List<Button> buttonsDeep = new List<Button>();
        CoinFlipDeep();
        for (int iDeep = 2;iDeep<25; iDeep++)
        {
            buttonsDeep.Add(GameObject.Find("LevelButtonDeep" + iDeep.ToString()).GetComponent<Button>());
        }
        CoinFlipDeep();

        while (tempDeep > -1)
        {
            buttonsDeep[tempDeep].GetComponent<Button>().interactable = true;
            tempDeep--;
        }
        CoinFlipDeep();
    }
}
