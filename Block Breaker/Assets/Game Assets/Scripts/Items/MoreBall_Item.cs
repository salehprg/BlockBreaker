using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBall_Item : Item
{
    public float BallAmount = 2;

    GameObject ball;
    public override void _Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    public override void DoItemTask()
    {
        base.DoItemTask();

        
        for(int i = 0;i < BallAmount; i++)
        {
            GameObject.Instantiate(ball , ball.transform.position , new Quaternion());
        }
        
    }
}
