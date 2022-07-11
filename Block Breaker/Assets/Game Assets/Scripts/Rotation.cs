using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float time;
    public float speed;
    public GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        Ball = GameObject.FindGameObjectWithTag("ball");
        if (Time.time > time && Ball != null)
        {
            gameObject.transform.Rotate(0,speed*Time.deltaTime,0);
        }
    }
}
