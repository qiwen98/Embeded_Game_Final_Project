using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public Vector2 moving = new Vector2();

    public FixedJoystick fixedJoystick;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h <= 0.1f && v <= 0.1f)
        {
            moving.x = fixedJoystick.inputVector.x;
            moving.y = fixedJoystick.inputVector.y;
        }else
        {
            moving.x = h;
            moving.y = v;
        }
    }
}
