using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Item : Item
{

    public override void DoItemTask(object arg)
    {
        base.DoItemTask();
        
        var ball = (GameObject)arg;
        if(ball.tag == "ball")
            Destroy(ball);
    }
}
