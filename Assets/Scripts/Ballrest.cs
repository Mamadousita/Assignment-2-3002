using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballrest : MonoBehaviour
{
     [Tooltip("Transform de la position de départ de la balle")]
    public Transform resetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                other.transform.position = resetPoint.position;
            }
        }
    }
}
