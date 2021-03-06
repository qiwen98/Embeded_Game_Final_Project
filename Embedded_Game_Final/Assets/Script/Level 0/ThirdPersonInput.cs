﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInput : MonoBehaviour
{
    public FixedJoystick LeftJoystick;


    public FixedButton Button;
    public FixedTouchField TouchField;
    protected ThirdPersonUserControl Control;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    private Vector3 fixVector;

    public float controlY, controlZ;

    public float maxControlZ = 4f;
    public float minControlZ = 1.0f;
    public float smooth = 10.0f;
    // Use this for initialization
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
        controlY = 2;
        controlZ = 4;

        fixVector = Vector3.down * 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        Control.m_Jump = Button.Pressed;

        Control.Hinput = LeftJoystick.inputVector.x;
        Control.Vinput = LeftJoystick.inputVector.y;
    }
}
