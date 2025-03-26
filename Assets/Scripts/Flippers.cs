using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class FlipperControl : MonoBehaviour
{
    public KeyCode inputKey = KeyCode.LeftArrow;
    public float motorSpeed = 1000f;
    public float motorForce = 10000f;
    public float flipAngle = 45f; // Angle à atteindre depuis la position de repos
    public bool invert = false;

    private HingeJoint hinge;
    private float restAngle;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useMotor = true;
        hinge.useLimits = true;

        // Enregistre la position de départ comme angle de repos
        restAngle = hinge.angle;

        // Applique les limites dynamiquement
        JointLimits limits = hinge.limits;
        limits.min = Mathf.Min(restAngle, restAngle + (invert ? -flipAngle : flipAngle));
        limits.max = Mathf.Max(restAngle, restAngle + (invert ? -flipAngle : flipAngle));
        hinge.limits = limits;
    }

    void Update()
    {
        JointMotor motor = hinge.motor;

        if (Input.GetKey(inputKey))
        {
            // Va vers l'angle de frappe
            motor.targetVelocity = invert ? -motorSpeed : motorSpeed;
        }
        else
        {
            // Revient à l'angle initial de repos
            motor.targetVelocity = invert ? motorSpeed : -motorSpeed;
        }

        motor.force = motorForce;
        hinge.motor = motor;
    }
}
