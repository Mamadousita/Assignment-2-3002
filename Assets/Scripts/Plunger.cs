using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
   public float pullForce = 200f;
    public float maxPull = 0.5f;
    public KeyCode inputKey = KeyCode.Space;

    private Rigidbody rb;
    private Vector3 restPosition;
    private bool isPulling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        restPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(inputKey))
        {
            isPulling = true;
        }

        if (Input.GetKeyUp(inputKey))
        {
            isPulling = false;
        }
    }

    void FixedUpdate()
    {
        if (isPulling)
        {
            if (Vector3.Distance(transform.position, restPosition) < maxPull)
            {
                // Applique une force vers l arriere
                rb.AddForce(transform.forward * pullForce);
            }
        }
    }
}
