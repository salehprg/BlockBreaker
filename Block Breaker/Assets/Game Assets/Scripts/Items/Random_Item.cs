using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Item : Item
{
    public List<Item> items;


    public override void DoItemTask()
    {
        base.DoItemTask();

        int randItem = Random.Range(0 , items.Count);
        items[randItem].DoItemTask();
    }
}
