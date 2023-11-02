using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float launchForce;
    public float forwardForce;
    public Rigidbody rb; 
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * launchForce + Vector3.forward * forwardForce, ForceMode.Impulse);
    }
}
