using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBall_Item : Item
{
    public float BallAmount = 2;


    public override void DoItemTask(object arg)
    {
        base.DoItemTask();
        var ball = GameObject.FindGameObjectWithTag("ball");
        
        for(int i = 0;i < BallAmount; i++)
        {
           var temp = GameObject.Instantiate(ball , ball.transform.position , new Quaternion());
           temp.transform.SetParent(transform.parent);
           temp.transform.localPosition = new Vector3(Random.Range(temp.transform.localPosition.x - 0.5f , temp.transform.localPosition.x + 0.5f)
                                                        , temp.transform.localPosition.y
                                                        , temp.transform.localPosition.z);
        }
        
    }
}
