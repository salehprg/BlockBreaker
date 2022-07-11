using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Item : Item
{
    public float slowmotion_time = 2;

    public GameObject bat;

    
    public override void _Start()
    {
        bat = GameObject.FindGameObjectWithTag("bat");
    }

    public override void DoItemTask()
    {
        base.DoItemTask();
        
        Debug.Log("Timer");
    }
}
