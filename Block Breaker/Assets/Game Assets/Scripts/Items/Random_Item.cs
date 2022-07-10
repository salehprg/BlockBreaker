using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Item : Item
{
    public List<Item> items;

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

        int randItem = Random.Range(0 , items.Count);
        items[randItem].DoItemTask();
    }
}
