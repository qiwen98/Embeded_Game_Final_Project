using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public Vector2 moving = new Vector2();

    public FixedJoystick fixedJoystick;

    void Update()
    {
        moving.x = fixedJoystick.inputVector.x;
        moving.y = fixedJoystick.inputVector.y;
    }
}
