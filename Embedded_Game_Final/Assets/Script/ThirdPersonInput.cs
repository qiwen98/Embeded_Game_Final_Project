using System.Collections;
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
        /*
        Vector3 desirePos = transform.position + fixVector +
            Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0f, controlY, minControlZ);

        RaycastHit hit;

        if(Physics.Linecast(Camera.main.transform.parent.position,desirePos,out hit))
        {
            controlZ = minControlZ;
        }else
        {
            controlZ = maxControlZ;
        }

        Control.m_Jump = Button.Pressed;
        Control.Hinput = LeftJoystick.inputVector.x;
        Control.Vinput = LeftJoystick.inputVector.y;

        //CameraAngle += RightJoystick.inputVector.x * CameraAngleSpeed;
        CameraAngle += TouchField.TouchDist.x * CameraAngleSpeed;


        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
            transform.position + fixVector + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0f, controlY, controlZ),Time.deltaTime * smooth);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + fixVector + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
        */
    }
}
