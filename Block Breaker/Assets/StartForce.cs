using UnityEngine;

public class StartForce : MonoBehaviour
{
    public Vector3 startForce;

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce, ForceMode.Impulse);
    }
}