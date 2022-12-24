using System.Collections;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    public Vector3 minForce , maxForce;
    public Rotation rotation;
    public Vector3 randomForce{
        get {
            return new Vector3(Random.Range(minForce.x , maxForce.x) , 
                                        0,
                                        Random.Range(minForce.z , maxForce.z));
        }
    }
    void Start()
    {
        rotation.enabled = true;
    }
}