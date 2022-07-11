using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Item : Item
{
    public GameObject shield;



    public override void DoItemTask()
    {
        base.DoItemTask();

        var bat = GameObject.FindGameObjectWithTag("bat");
        var temp = GameObject.Instantiate(shield , bat.transform.position , new Quaternion());
        temp.transform.SetParent(bat.transform.parent);

        temp.transform.localPosition = new Vector3(0,0,4.9f);
        temp.transform.localEulerAngles = new Vector3(-90,0,0);
    }
}
