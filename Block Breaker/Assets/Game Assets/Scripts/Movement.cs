using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float normal_speed_x;
    public float speed_x;

    public float min_x = 0;
    public float max_x = 0;

    public float disableTimer;

    bool rightLimit = false , leftlimit = false;


    void Start()
    {
       normal_speed_x = speed_x;
    }

    void Update()
    {
        if(disableTimer <= Time.time)
        {
            speed_x = normal_speed_x;
            Time.timeScale = 1;
        }

        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0, 0);
        movement = Vector3.ClampMagnitude(movement, 1);

        if((!leftlimit && x < 0) || 
            (!rightLimit && x > 0))
        {
            transform.Translate(movement * -speed_x * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Rightwall")
            rightLimit = true;
        if(other.gameObject.tag == "Leftwall")
            leftlimit = true;
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Rightwall")
            rightLimit = false;
        if(other.gameObject.tag == "Leftwall")
            leftlimit = false;
    }

}
