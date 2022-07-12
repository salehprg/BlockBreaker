using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject equip_effect;
    public GameObject movement_effect;
    public float speed;

    Vector3 endPos;

    private void Start() 
    {
        endPos = new Vector3(transform.localPosition.x , transform.localPosition.y , 12);

        _Start();
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition , endPos , Time.deltaTime * speed);

        _Update();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "ball" || other.gameObject.tag == "bat" )
        {
            DoItemTask(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "endwall")
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void _Start(){}
    public virtual void _Update(){}

    public virtual void DoItemTask(object arg = null)
    {
        if(equip_effect != null)
        {
            var temp = GameObject.Instantiate(equip_effect , transform.position , new Quaternion());
            Destroy(temp , 5);
        }
    }


}
