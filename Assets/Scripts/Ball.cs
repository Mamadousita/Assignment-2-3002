using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    [Header("Gravité inclinée")]
    public float inclineAngle = -15f;         // Inclinaison virtuelle de la table
    public float gravityStrength = 9.81f;     // Force de gravité personnalisée

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Désactiver la gravité Unity
    }

    void FixedUpdate()
    {
        float angleRad = inclineAngle * Mathf.Deg2Rad;
        Vector3 gravityDir = new Vector3(0f, -Mathf.Sin(angleRad), -Mathf.Cos(angleRad));
        rb.AddForce(gravityDir * gravityStrength, ForceMode.Acceleration);
    }

    void OnDrawGizmosSelected()
    {
        // Visualise la direction de la gravité inclinée
        float angleRad = inclineAngle * Mathf.Deg2Rad;
        Vector3 gravityDir = new Vector3(0f, -Mathf.Sin(angleRad), -Mathf.Cos(angleRad));
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, gravityDir.normalized * 2f);
    }
}