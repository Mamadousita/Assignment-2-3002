using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class FlipperControl : MonoBehaviour
{
    public KeyCode inputKey = KeyCode.LeftArrow;
    public float motorSpeed = 1000f;
    public float motorForce = 10000f;
    public bool invert = false;

    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useMotor = true;
    }

    void Update()
    {
        JointMotor motor = hinge.motor;

        if (Input.GetKey(inputKey))
        {
            motor.targetVelocity = invert ? -motorSpeed : motorSpeed;
        }
        else
        {
            motor.targetVelocity = invert ? motorSpeed : -motorSpeed;
        }

        motor.force = motorForce;
        hinge.motor = motor;
    }
}

