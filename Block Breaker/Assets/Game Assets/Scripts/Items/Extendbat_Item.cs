using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extendbat_Item : Item
{

    public GameObject bat;

    
    public override void _Start()
    {
        bat = GameObject.FindGameObjectWithTag("bat");
    }

    // Update is called once per frame

    public override void DoItemTask()
    {
        base.DoItemTask();
        
        bat.transform.localScale = new Vector3(bat.transform.localScale.x + 0.15f , bat.transform.localScale.y,
                                                bat.transform.localScale.z);
    }
}
