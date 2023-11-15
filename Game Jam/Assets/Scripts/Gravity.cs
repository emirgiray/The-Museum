using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;

    public float gravity = 9.81f;

    public bool autoOrient = false;
    public float autoOrientSpeed = 1f;
    public Transform gravityTarget;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessGravity(); 
    }
    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * rb.mass);
        if (autoOrient)
        {
            AutoOrient(-diff);
        }
    }
    void AutoOrient(Vector3 down)
    {
        Quaternion oreintDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, oreintDirection, autoOrientSpeed * Time.deltaTime);
    }
}
