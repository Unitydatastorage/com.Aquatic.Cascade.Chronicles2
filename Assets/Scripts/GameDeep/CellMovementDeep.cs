using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CellMovementDeep : MonoBehaviour
{

    bool startDeep = false;
    Vector3 position1Deep;
    Vector3 position2Deep;

    float CoinFlipDeep()
    {
        System.Random rDeep = new System.Random();
        int rIntDeep = rDeep.Next(0, 10);
        if (rIntDeep > 5) { return Time.time; }
        else { return CoinFlipDeep(); };
    }
    public void TransitionDeep(RectTransform firstDeep, RectTransform secondDeep)
    {
        CoinFlipDeep();
        position1Deep = firstDeep.localPosition;
        position2Deep = secondDeep.localPosition;
        startDeep = true;
        CoinFlipDeep();
        if (firstDeep.localPosition != position2Deep)
        {
            firstDeep.localPosition = Vector3.Lerp(position1Deep, position2Deep, 0);
        }
        CoinFlipDeep();
        if (secondDeep.localPosition != position1Deep)
        {
            secondDeep.localPosition = Vector3.Lerp(position2Deep, position1Deep, 0);
        }
    }


}
