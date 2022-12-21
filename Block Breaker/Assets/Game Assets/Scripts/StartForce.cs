using System.Collections;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    public Vector3 minForce , maxForce;
    public Vector3 randomForce{
        get {
            return new Vector3(Random.Range(minForce.x , maxForce.x) , 
                                        0,
                                        Random.Range(minForce.z , maxForce.z));
        }
    }
    void Start()
    {
        // Vector3 _randomForce = randomForce;
                                        
        // Rigidbody rigidbody = GetComponent<Rigidbody>();
        // rigidbody.AddForce(randomForce, ForceMode.Impulse);
        // rigidbody.AddTorque(randomForce , ForceMode.Impulse);
    }
}