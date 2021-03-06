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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        var temp = GameObject.Instantiate(deadParticle , transform.position , new Quaternion());
        Destroy(temp , 5);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "brick")
        {
            brickTouchEvent?.Invoke();
            other.gameObject.GetComponent<Break>().Damage(1);
        }
        else if(other.gameObject.tag == "endwall")
        {
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
