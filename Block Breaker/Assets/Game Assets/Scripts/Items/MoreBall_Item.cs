using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBall_Item : Item
{
    public float BallAmount = 2;

    public GameObject bat;

    
    void Start()
    {
        bat = GameObject.FindGameObjectWithTag("bat");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoItemTask()
    {
        base.DoItemTask();

        var ball = GameObject.FindGameObjectWithTag("ball");
        for(int i = 0;i < BallAmount; i++)
        {
            GameObject.Instantiate(ball , ball.transform.position , new Quaternion());
        }
        
    }
}
