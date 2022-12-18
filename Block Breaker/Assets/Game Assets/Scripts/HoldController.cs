using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HoldController : MonoBehaviour
{
    public UnityEvent onHolding;
    bool holding = false;
    void Update()
    {
        if(holding)
        {
            onHolding.Invoke();
        }
    }

    public void onPointerDownRaceButton()
    {
        holding = true;
    }
    public void onPointerUpRaceButton()
    {
        holding = false;
    }



}
