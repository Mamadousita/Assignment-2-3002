using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveBumper : MonoBehaviour
{
    [Tooltip("Facteur de ralentissement (entre 0.0 et 1.0)")]
    public float slowFactor = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null && collision.gameObject.CompareTag("Ball"))
        {
            // reduction volicity
            rb.velocity *= slowFactor;
        }
    }
}
