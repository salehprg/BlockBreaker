using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Item : Item
{
    public GameObject ball;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoItemTask()
    {
        base.DoItemTask();
        
        Destroy(ball);
    }
}
