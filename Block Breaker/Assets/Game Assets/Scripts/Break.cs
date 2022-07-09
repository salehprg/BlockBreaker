using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public float hp = 2.0f;
    public Color light;
    
    int currentHit = 0;

    void Start()
    {
        if(hp == 5)
        {
            GetComponent<Renderer>().material.SetColor("Albedo" , light);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "ball")
        {
            currentHit++;
        }

        if(currentHit >= hp)
        {
            Destroy(this.gameObject);
        }
    }
}
