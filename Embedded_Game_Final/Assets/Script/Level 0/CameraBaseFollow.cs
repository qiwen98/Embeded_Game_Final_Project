using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBaseFollow : MonoBehaviour
{
    public Transform player;
    public FixedJoystick LeftJoystick;
    public FixedButton JumpButton;
    public FixedButton NextButton;
    public FixedTouchField TouchField;
    protected PlayerController Control;

    public float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    public Vector3 fixVector;

    public float controlY, controlZ;

    public bool canControlY;
    public bool lockCameraDirection;
    // Use this for initialization
    void Start()
    {
        Control = player.GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Control.h = Input.GetAxis("Horizontal");
            Control.v = Input.GetAxis("Vertical");
        }
        else
        {
            //Control.m_Jump = Button.Pressed;
            Control.h = LeftJoystick.inputVector.x;
            Control.v = LeftJoystick.inputVector.y;
        }

        //CameraAngle += RightJoystick.inputVector.x * CameraAngleSpeed;
        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;

        if(canControlY) controlY -= TouchField.TouchDist.y*0.01f;
        if (lockCameraDirection) handleCameraAngle();

        if (controlY >= 6f) controlY = 6f;
        else if (controlY <= -1f) controlY = -1f;

        transform.position = player.transform.position + fixVector + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0f, controlY, controlZ);
        transform.rotation = Quaternion.LookRotation(player.transform.position + fixVector + Vector3.up * 2f - transform.position, Vector3.up);
    }

    void handleCameraAngle()
    {
        CameraAngle = (float)((int)CameraAngle % 360);
        if (CameraAngle <= 0f) CameraAngle += 360f;
        if (Mathf.Abs(CameraAngle - 0f) <= 45) CameraAngle = 0f;
        else if(Mathf.Abs(CameraAngle - 90f) <= 45) CameraAngle = 90f;
        else if(Mathf.Abs(CameraAngle - 180f) <= 45) CameraAngle = 180f;
        else if(Mathf.Abs(CameraAngle - 270f) <= 45) CameraAngle = 270f;
    }

}
