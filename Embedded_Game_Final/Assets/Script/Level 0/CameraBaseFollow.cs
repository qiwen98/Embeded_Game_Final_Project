using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBaseFollow : MonoBehaviour
{
    public Transform player;
    public FixedJoystick LeftJoystick;
    public FixedButton Button;
    public FixedTouchField TouchField;
    protected ThirdPersonUserControl Control;

    protected float CameraAngle;
    protected float CameraAngleSpeed = 0.2f;

    private Vector3 fixVector;

    public float controlY, controlZ;


    // Use this for initialization
    void Start()
    {
        Control = player.GetComponent<ThirdPersonUserControl>();
        controlY = 2;
        controlZ = 4;

        fixVector = Vector3.down * 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        //Control.m_Jump = Button.Pressed;
        Control.Hinput = LeftJoystick.inputVector.x;
        Control.Vinput = LeftJoystick.inputVector.y;

        //CameraAngle += RightJoystick.inputVector.x * CameraAngleSpeed;
        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;
        controlY += TouchField.TouchDist.y*0.01f;

        if (controlY >= 6f) controlY = 6f;
        else if (controlY <= -1f) controlY = -1f;

        transform.position = player.transform.position + fixVector + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0f, controlY, controlZ);
        transform.rotation = Quaternion.LookRotation(player.transform.position + fixVector + Vector3.up * 2f - transform.position, Vector3.up);

    }
}
