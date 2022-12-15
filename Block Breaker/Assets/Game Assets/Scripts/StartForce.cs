using System.Collections;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    public Vector3 minForce , maxForce;
    void Start()
    {
        Vector3 randomForce = new Vector3(Random.Range(minForce.x , maxForce.x) , 
                                        Random.Range(minForce.y , maxForce.y),
                                        Random.Range(minForce.z , maxForce.z));
                                        
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(randomForce, ForceMode.Impulse);
        rigidbody.AddTorque(randomForce , ForceMode.Impulse);
    }
}