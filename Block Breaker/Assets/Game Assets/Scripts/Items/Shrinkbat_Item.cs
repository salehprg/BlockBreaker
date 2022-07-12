using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinkbat_Item : Item
{

    public GameObject bat;
    public float minExtend;
    
    public override void _Start()
    {
        
    }

    // Update is called once per frame

    public override void DoItemTask(object arg)
    {
        base.DoItemTask();
        
        bat = GameObject.FindGameObjectWithTag("bat");
        
        if(bat.transform.localScale.x - 0.15f >= minExtend)
        {
            bat.transform.localScale = new Vector3(bat.transform.localScale.x - 0.15f , bat.transform.localScale.y,
                                                    bat.transform.localScale.z);
        }
    }
}
