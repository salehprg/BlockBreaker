using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCheck : MonoBehaviour
{
    public ParticleSystem deadParticle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        GameObject.Instantiate(deadParticle , transform.position , new Quaternion());
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "endwall")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "shield")
        {
            Destroy(other.gameObject);
        }
    }
}
