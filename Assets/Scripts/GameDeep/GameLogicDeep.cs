using System;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class GameLogicDeep : MonoBehaviour
{

    public CellDeep firstClickedDeep;
    public bool boolFirstDeep = false;

    public CellDeep secondClickedDeep;
    public bool boolSecondDeep = false;
    System.Random rDeep = new System.Random();
    public Text scoreTextDeep;

    public Sprite sprite1Deep;
    public Sprite sprite2Deep;
    public Sprite sprite3Deep;
    public Sprite sprite4Deep;

    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }

    public bool firstMoveFinishedDeep =false;
    public bool secondMoveFinishedDeep = false;


   
    bool destructionHappenedDeep = false;

    public int pointsDeep = 0;
    public int pointGoalDeep = 5000;
    public int pickedLevelDeep = 0;
    bool pointCountDeep = false;


    List<int> horizontal;
    List<int> vertical;

    public void TryCheckDeep()
    {
        CoinFlipDeep();

        for (int jDeep = 1; jDeep < 43; jDeep++)
        {

            if (horizontal.Contains(jDeep)){
                
                if ((GameObject.Find("GameButtonDeep" + (jDeep + 1).ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID() == GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID()) && (GameObject.Find("GameButtonDeep" + (jDeep - 1).ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID() == GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID()))
                {
                    if (!GameObject.Find("GameButtonDeep" + (jDeep - 1).ToString() ).GetComponent<CellDeep>().needsDestructionDeep)
                    {
                        GameObject.Find("GameButtonDeep" + (jDeep - 1).ToString() ).GetComponent<CellDeep>().needsDestructionDeep = true;
                        if (pointCountDeep)
                            pointsDeep += 100;
                    }
                    if (!GameObject.Find("GameButtonDeep" + (jDeep).ToString() ).GetComponent<CellDeep>().needsDestructionDeep)
                    {
                        GameObject.Find("GameButtonDeep" + (jDeep).ToString() ).GetComponent<CellDeep>().needsDestructionDeep = true;
                        if (pointCountDeep)
                            pointsDeep += 100;
                    }
                    if (!GameObject.Find("GameButtonDeep" + (jDeep + 1).ToString() ).GetComponent<CellDeep>().needsDestructionDeep)
                    {
                        GameObject.Find("GameButtonDeep" + (jDeep + 1).ToString() ).GetComponent<CellDeep>().needsDestructionDeep = true;
                        if (pointCountDeep)
                            pointsDeep += 100;
                    }
                }
            }
            CoinFlipDeep();
            CoinFlipDeep();
            if (vertical.Contains(jDeep))
            {
             
                if ((GameObject.Find("GameButtonDeep" + (jDeep + 6).ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID() == GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID()) && (GameObject.Find("GameButtonDeep" + (jDeep - 6).ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID() == GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().spriteDeep.GetInstanceID()))
                {
                    if (!GameObject.Find("GameButtonDeep" + (jDeep - 6).ToString()).GetComponent<CellDeep>().needsDestructionDeep)
                    {
                        GameObject.Find("GameButtonDeep" + (jDeep - 6).ToString() ).GetComponent<CellDeep>().needsDestructionDeep = true;
                        if (pointCountDeep)
                            pointsDeep += 100;
                    }
                    if (!GameObject.Find("GameButtonDeep" + (jDeep).ToString() ).GetComponent<CellDeep>().needsDestructionDeep)
                    {
                        GameObject.Find("GameButtonDeep" + (jDeep).ToString() ).GetComponent<CellDeep>().needsDestructionDeep = true;
                        if (pointCountDeep)
                            pointsDeep += 100;
                    }
                    if (!GameObject.Find("GameButtonDeep" + (jDeep + 6).ToString() ).GetComponent<CellDeep>().needsDestructionDeep)
                    {
                        GameObject.Find("GameButtonDeep" + (jDeep + 6).ToString() ).GetComponent<CellDeep>().needsDestructionDeep = true;
                        if (pointCountDeep)
                            pointsDeep += 100;
                    }
                }
            }


        }
        CoinFlipDeep();
        bool happened = false;
        for (int jDeep = 1; jDeep < 43; jDeep++)
        {
            CoinFlipDeep();
            if ( GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().needsDestructionDeep){
                GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().needsDestructionDeep = false;
                NewDestroyDeep(GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>(), jDeep);
                happened = true;
            }
        }
        CoinFlipDeep();
        if (happened) { destructionHappenedDeep = true;
            if (pointCountDeep) GameObject.Find("MainCameraDeep").GetComponent<SoundManagerDeep>().PlayPingDeep();
        }
        else destructionHappenedDeep= false;
        CoinFlipDeep();

    }


    public void NewDestroyDeep(CellDeep targetDeep,int numberDeep)
    {
        CoinFlipDeep();
        if (numberDeep < 7)
        {        
            targetDeep.spriteDeep = RandomSpriteDeep(GameObject.Find("GameButtonDeep" + (numberDeep + 6).ToString() ).GetComponent<CellDeep>().spriteDeep);
        }
        else
        {
            targetDeep.spriteDeep = GameObject.Find("GameButtonDeep" + (numberDeep-6).ToString() ).GetComponent<CellDeep>().spriteDeep;
            NewDestroyDeep(GameObject.Find("GameButtonDeep" + (numberDeep - 6).ToString() ).GetComponent<CellDeep>(), numberDeep - 6);
        }
        CoinFlipDeep();
    }

    public void GameStartDeep()
    {
        CoinFlipDeep();
        pointCountDeep = false;
        horizontal = new List<int>
        {2,3,4,5,8,9,10,11,14,15,16,17,20,21,22,23,26,27,28,29,32,33,34,35,38,39,40,41};
        CoinFlipDeep();
        vertical = new List<int>
        {7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36};
        CoinFlipDeep();


        CoinFlipDeep();

        for (int jDeep = 1; jDeep < 43; jDeep++)
        {
            GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().spriteDeep = RandomSpriteDeep();
            GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().CellStartDeep();

        }

        CoinFlipDeep();
        pointsDeep = 0;
        pointGoalDeep = 5000 + pickedLevelDeep * 500;



        CoinFlipDeep();

        BigGameCheckDeep();
        pointCountDeep = true;
        CoinFlipDeep();
    }
    public Sprite RandomSpriteDeep(Sprite previousSprite = null)
    {
        Sprite tempSpriteDeep;
        int rIntDeep = rDeep.Next(0, 4);
        CoinFlipDeep();
        if (rIntDeep == 0) tempSpriteDeep = sprite1Deep;
        else if (rIntDeep == 1) tempSpriteDeep = sprite2Deep;
        else if (rIntDeep == 2) tempSpriteDeep = sprite3Deep;
        else tempSpriteDeep = sprite4Deep;
        CoinFlipDeep();
        if (previousSprite != null)
        {
            while (previousSprite.GetInstanceID() == tempSpriteDeep.GetInstanceID())
            {
                rIntDeep = rDeep.Next(0, 4);
                if (rIntDeep == 0) tempSpriteDeep = sprite1Deep;
                else if (rIntDeep == 1) tempSpriteDeep = sprite2Deep;
                else if (rIntDeep == 2) tempSpriteDeep = sprite3Deep;
                else tempSpriteDeep = sprite4Deep;
            }
        }

        CoinFlipDeep();
        return tempSpriteDeep;
    }

    void SwapDeep()
    {
     
        if ((Math.Abs(firstClickedDeep.positionXDeep - secondClickedDeep.positionXDeep) +Math.Abs(firstClickedDeep.positionYDeep - secondClickedDeep.positionYDeep))==1)
        {
            CoinFlipDeep();
            Vector3 firstTempDeep = secondClickedDeep.currentPositionDeep;
            Vector3 secondTempDeep = firstClickedDeep.currentPositionDeep;
            Sprite temp1 = secondClickedDeep.spriteDeep;
            Sprite temp2 = firstClickedDeep.spriteDeep;
            firstClickedDeep.StartMoveDeep(firstTempDeep, temp1);
            secondClickedDeep.StartMoveDeep(secondTempDeep, temp2);
            CoinFlipDeep();
        }
        else
        {
            firstClickedDeep.RefreshSpriteDeep();
            firstClickedDeep = null;
            secondClickedDeep = null;
            boolFirstDeep = false;
            CoinFlipDeep();
            boolSecondDeep = false;
        }
        CoinFlipDeep();
    }

 


    public void BigGameCheckDeep()
    {
        TryCheckDeep();
        CoinFlipDeep();
        while (destructionHappenedDeep)
        {
            TryCheckDeep();
            CoinFlipDeep();
        }
        for (int jDeep = 1; jDeep < 43; jDeep++)
        {
            GameObject.Find("GameButtonDeep" + jDeep.ToString() ).GetComponent<CellDeep>().RefreshSpriteDeep();
            CoinFlipDeep();

        }
        CoinFlipDeep();
        scoreTextDeep.text = "Score:\n" + pointsDeep.ToString()+"/"+pointGoalDeep.ToString();
    }



    void Update()
    {
        if (GameObject.Find("MainCameraDeep").GetComponent<CanvasHolderDeep>().gameCanvasDeep.enabled)
        {
            if (pointsDeep >= pointGoalDeep)
            {
                CoinFlipDeep();
                GameObject.Find("MainCameraDeep").GetComponent<CanvasHolderDeep>().MoveDeep("winDeep");
            }
        }

        if (boolFirstDeep && boolSecondDeep)
        {
            CoinFlipDeep();
            boolFirstDeep = false;
            boolSecondDeep = false;
            CoinFlipDeep();
            if (firstClickedDeep != secondClickedDeep) SwapDeep();
            else firstClickedDeep.RefreshSpriteDeep();         
           
        }

        if (firstMoveFinishedDeep && secondMoveFinishedDeep)
        {
            firstMoveFinishedDeep = false;
            secondMoveFinishedDeep = false;
            BigGameCheckDeep();
        }
    }
}
