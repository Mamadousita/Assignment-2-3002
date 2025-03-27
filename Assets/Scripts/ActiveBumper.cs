using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBumper : MonoBehaviour
{
    [Tooltip("Force appliquée à la balle après rebond")]
    public float bounceForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null && collision.gameObject.CompareTag("Ball"))
        {
            Vector3 incomingVelocity = rb.velocity;
            Vector3 normal = collision.contacts[0].normal;

            // Calcul manuel de la réflexion
            Vector3 reflectedVelocity = Vector3.Reflect(incomingVelocity, normal).normalized;

            // Appliquer la nouvelle direction avec une force
            rb.velocity = reflectedVelocity * bounceForce;
        }
    }
}
