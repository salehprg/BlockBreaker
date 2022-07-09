using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed_x;
    public float min_x = 0;
    public float max_x = 0;

    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(x, 0, 0);
        movement = Vector3.ClampMagnitude(movement, 1);
        
        if((transform.position.x > min_x && x > 0) || 
            (transform.position.x < max_x && x < 0))
        {
            transform.Translate(movement * -speed_x * Time.deltaTime);
        }
    }
}
