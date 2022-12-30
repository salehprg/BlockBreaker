using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent brickTouchEvent;
    public UnityEvent wallTouchEvent;
    public UnityEvent batTouchEvent;
    public GameObject deadParticle;
    public int BrickCollisionCount=0;
    public StartForce startForce;

    public float maxspeed = 15 , minspeed = 5 , max_increase = 110 , increase_speed = 5 , increase_time = 15;
    float lastTime = 0 , last_time_hit = 0;

    Rigidbody myrigidbody;
    

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();
        startForce = GetComponent<StartForce>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!startForce.enabled)
            return;

        if(maxspeed < max_increase && Time.time - lastTime > increase_time)
        {
            lastTime = Time.time;
            maxspeed += increase_speed;
        }

        if(myrigidbody.velocity.sqrMagnitude < minspeed)
        {
            Vector3 velocity = myrigidbody.velocity;
            if(velocity.sqrMagnitude == 0)
                velocity = startForce.randomForce;

            myrigidbody.AddForce(velocity / 2 , ForceMode.VelocityChange);
        }
        else if(myrigidbody.velocity.sqrMagnitude > minspeed && myrigidbody.velocity.sqrMagnitude < maxspeed)
        {
            Vector3 velocity = myrigidbody.velocity;
            myrigidbody.AddForce(velocity * Time.deltaTime , ForceMode.Impulse);
        }
        else if(myrigidbody.velocity.sqrMagnitude > maxspeed)
        {
            Vector3 velocity = myrigidbody.velocity;
            myrigidbody.AddForce((-velocity) * Time.deltaTime , ForceMode.Impulse);
        }
    }
    
    private void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "brick")
        {
            BrickCollisionCount++;
            brickTouchEvent?.Invoke();
            other.gameObject.GetComponent<Break>().Damage(1);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "brick")
        {
            BrickCollisionCount++;
            brickTouchEvent?.Invoke();
            other.gameObject.GetComponent<Break>().Damage(1);
        }
        else if(other.gameObject.tag == "endwall")
        {
            var temp = GameObject.Instantiate(deadParticle , transform.position , new Quaternion());
            Destroy(temp , 5);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "shield")
        {
            wallTouchEvent?.Invoke();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag.ToLower().Contains("wall"))
        {
            wallTouchEvent?.Invoke();
        }
        else if(other.gameObject.tag.ToLower().Contains("bat"))
        {
            batTouchEvent?.Invoke();
        }
    }
}
