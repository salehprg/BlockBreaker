using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ParticleSystem equip_effect;
    public ParticleSystem movement_effect;
    public string Ball_tag;

    private void OnTriggerEnter(Collider other) {
        Debug.DrawLine(transform.position, transform.position+new Vector3(5,0,0));
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "ball"){
            DoItemTask();
        }
    }
    void Update()
    {
        
    }

    public virtual void DoItemTask(){
        if(equip_effect != null)
            GameObject.Instantiate(equip_effect , transform.position , new Quaternion());
    }


}
