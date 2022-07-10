using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Item : Item
{
    public float slowmotion_time = 2;

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
        
        Debug.Log("Timer");
    }
}
