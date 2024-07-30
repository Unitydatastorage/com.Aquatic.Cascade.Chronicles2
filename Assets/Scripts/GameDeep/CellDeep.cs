using System.Collections;
using UnityEngine;


public class CellDeep : MonoBehaviour
{

    public int positionXDeep;
    public int positionYDeep;
    public Sprite spriteDeep;
    public Vector3 currentPositionDeep;
    public bool needsDestructionDeep = false;




    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }

    public void OnClickDeep()
    {
        CoinFlipDeep();
        GameObject.Find("MainCameraDeep").GetComponent<SoundManagerDeep>().PlayClickDeep();
        if (!GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().boolFirstDeep)
        {
            CoinFlipDeep();
            GetComponent<UnityEngine.UI.Image>().color = Color.green;
            GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().firstClickedDeep = this;
            GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().boolFirstDeep = true;
        }
        else if (!GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().boolSecondDeep)
        {
            CoinFlipDeep();
            GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().secondClickedDeep = this;
            GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().boolSecondDeep = true;
        }
    }

    public void RefreshSpriteDeep()
    {
        CoinFlipDeep();
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        CoinFlipDeep();
        GetComponent<UnityEngine.UI.Image>().sprite = spriteDeep;
    }




    public void StartMoveDeep(Vector3 destinationDeep, Sprite newSpriteDeep)
    {
        CoinFlipDeep();
        GetComponent<UnityEngine.UI.Image>().color = Color.white;
        StartCoroutine(moveObjectDeep(destinationDeep, newSpriteDeep));
        CoinFlipDeep();
    }

    public IEnumerator moveObjectDeep(Vector3 destinationDeep, Sprite newSpriteDeep)
    {
        CoinFlipDeep();
        float totalMovementTimeDeep = 1f; 
        float currentMovementTimeDeep = 0f;
        CoinFlipDeep();
        while (Vector3.Distance(transform.localPosition, destinationDeep) > 0)
        {
            currentMovementTimeDeep += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(currentPositionDeep, destinationDeep, currentMovementTimeDeep / totalMovementTimeDeep);
            yield return null;
        }
        transform.localPosition = currentPositionDeep;
        CoinFlipDeep();
        spriteDeep = newSpriteDeep;
        RefreshSpriteDeep();
        CoinFlipDeep();
        if (GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().firstMoveFinishedDeep == false)
        {
            CoinFlipDeep();
            GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().firstMoveFinishedDeep = true;
        }
        else GameObject.Find("GameCanvasDeep").GetComponent<GameLogicDeep>().secondMoveFinishedDeep = true;

    }


    public void CellStartDeep()
    {
        CoinFlipDeep();
        currentPositionDeep = transform.localPosition;
        RefreshSpriteDeep();
    }

  
   
}
