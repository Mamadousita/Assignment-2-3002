using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlungerPuller : MonoBehaviour
{
    public float inclineAngleX = -15f; // pente de la table
    public float pullForce = 200f;     // force d’aspiration vers l’arrière
    public KeyCode pullKey = KeyCode.Space;

    private Rigidbody rb;
    private Vector3 pullDirection;

    private bool isPulling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Calcul direction de recul en fonction de l'angle X
        float angleRad = inclineAngleX * Mathf.Deg2Rad;
        pullDirection = new Vector3(0f, Mathf.Sin(angleRad), -Mathf.Cos(angleRad));
    }

    void Update()
    {
        if (Input.GetKey(pullKey))
            isPulling = true;
        if (Input.GetKeyUp(pullKey))
            isPulling = false;
    }

    void FixedUpdate()
    {
        if (isPulling)
        {
            rb.AddForce(-pullDirection * pullForce, ForceMode.Force);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float angleRad = inclineAngleX * Mathf.Deg2Rad;
        Vector3 dir = new Vector3(0f, Mathf.Sin(angleRad), -Mathf.Cos(angleRad));
        Gizmos.DrawRay(transform.position, dir * 2f);
    }
}
