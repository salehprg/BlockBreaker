using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed_x;
    public float speed_y;
    public float speed_z;
    public Rigidbody rigidbody;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float x = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(x, 0, 0);
            movement = Vector3.ClampMagnitude(movement, 1);

            transform.Translate(movement * -speed_x * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float x = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(x, 0, 0);
            movement = Vector3.ClampMagnitude(movement, 1);

            transform.Translate(movement * -speed_x * Time.deltaTime);
        }
    }
}
