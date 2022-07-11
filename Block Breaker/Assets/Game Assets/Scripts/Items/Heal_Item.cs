using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Item : Item
{


    public override void DoItemTask(object arg)
    {
        base.DoItemTask();
        
        var ball = GameObject.FindGameObjectWithTag("ball");
        GameObject.Instantiate(ball , ball.transform.position , new Quaternion());
    }
}
