using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject equip_effect;
    public GameObject movement_effect;
    public string Ball_tag;
    public float speed;

    GameObject bat;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "ball"){
            DoItemTask();
            Destroy(this.gameObject);
        }
    }
    private void Start() 
    {
        bat = GameObject.FindGameObjectWithTag("bat");
    }

    void Update()
    {
        Vector3 newPos = new Vector3(transform.localPosition.x , transform.localPosition.y , 6);

        transform.localPosition = Vector3.Lerp(transform.localPosition , newPos , Time.deltaTime * speed);
    }

    public virtual void DoItemTask()
    {
        if(equip_effect != null)
            GameObject.Instantiate(equip_effect , transform.position , new Quaternion());
    }


}
