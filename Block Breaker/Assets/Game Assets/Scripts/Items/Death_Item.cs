using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Item : Item
{
    public GameObject ball;


    public override void DoItemTask()
    {
        base.DoItemTask();
        
        ball = GameObject.FindGameObjectWithTag("ball");
        Destroy(ball);
    }
}
