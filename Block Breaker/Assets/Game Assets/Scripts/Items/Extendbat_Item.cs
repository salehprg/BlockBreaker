using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extendbat_Item : Item
{

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
        
        bat.transform.localScale = new Vector3(bat.transform.localScale.x + 0.1f , bat.transform.localScale.y,
                                                bat.transform.localScale.z);
    }
}
