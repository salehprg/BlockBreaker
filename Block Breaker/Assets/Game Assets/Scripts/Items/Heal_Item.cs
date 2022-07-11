using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Item : Item
{
    GameObject ball;
    public override void _Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
    }


    public override void DoItemTask()
    {
        base.DoItemTask();
        
        GameObject.Instantiate(ball , ball.transform.position , new Quaternion());
    }
}
