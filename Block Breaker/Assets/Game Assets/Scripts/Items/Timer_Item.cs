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

    public override void DoItemTask(object arg)
    {
        base.DoItemTask();
        Movement movement = bat.GetComponent<Movement>();

        Time.timeScale = 0.5f;

        movement.disableTimer = Time.time + slowmotion_time;
        movement.normal_speed_x = movement.speed_x;
        movement.speed_x *= 1 / Time.timeScale;

    }
}
