using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ParticleSystem equip_effect;
    public ParticleSystem movement_effect;
    public string Ball_tag;

    
    void Update()
    {
        
    }

    public virtual void DoItemTask(){
        GameObject.Instantiate(equip_effect , transform.position , new Quaternion());
    }


}
