using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ButtonState
{
    JOYSTICK0 = 0,
    JOYSTICK1 = 1,
    JOYSTICK2 = 2,
    JOYSTICK3 = 3,
    JOYSTICK8 = 4,
    EMPTY = 5
}
public class PlayerController : MonoBehaviour
{
    //私有变量用小驼峰
    #region Private Members

    private Animator animator;

    private CharacterController cc;

    private float gravity = 15.0f;

    private Vector3 moveDirection = Vector3.zero;

    private int startHealth;

    private int startFood;

    private int dJumpCounter;

    #endregion

    //公有变量用大驼峰
    #region Public Members

    public float Speed = 1f;

    public float RotationSpeed = 100.0f;

    public GameObject Hand;

    public float JumpSpeed = 8f;

    public HUD Hud;

    public float h, v;



    public int nrOfAlowedDJumps = 2;

    #endregion

    #region Health & Hunger

    [Tooltip("Amount of health")]
    public int Health = 100;

    [Tooltip("Amount of food")]
    public int Food = 100;

    [Tooltip("Rate in seconds in which the hunger increases")]
    public float HungerRate = 0.1f;
    #endregion

    private Transform m_Cam;

    Vector3 m_GroundNormal;
    float m_TurnAmount;
    float m_ForwardAmount;
    [SerializeField] float m_MovingTurnSpeed = 360;
    [SerializeField] float m_StationaryTurnSpeed = 180;
    [SerializeField] float m_GroundCheckDistance = 0.8f;

    public CameraBaseFollow cam;


    public void IncreaseHunger()
    {

    }

    public ButtonState buttonState;

    // Start is called before the first frame update
    void Start()
    {
        m_Cam = Camera.main.transform;

        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        buttonState = ButtonState.EMPTY;
    }



    private int Punching_1_Hash = Animator.StringToHash("Base Layer.Punching");

    private void LateUpdate()
    {
        handleWalk();

        handleKeyboardEvent();
    }


    private void handleWalk()
    {

        //Interact with the item
        if (Input.GetKeyDown(KeyCode.F))
        {
            //捡起东西的操作
        }

        if (buttonState == ButtonState.JOYSTICK1)
        {
            if (true)//判断是否有按到别的东西
            {
                animator.SetTrigger("punching");
            }
        }



        CheckGroundStatus();

        // Move forward / backward
        if (Mathf.Abs(h) >= 0.1f || Mathf.Abs(v) >= 0.1f)
        {
            //transform.Rotate(0, h * RotationSpeed, 0);
            Vector3 forward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = v * forward + h * m_Cam.right;

            cc.Move((v * forward + h * m_Cam.right) * 0.1f);
            animator.SetBool("walk", true);

            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);
            move = Vector3.ProjectOnPlane(move, m_GroundNormal);
            m_TurnAmount = Mathf.Atan2(move.x, move.z);
            m_ForwardAmount = move.z;

            // help the character turn faster (this is in addition to root rotation in the animation)
            float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
            transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
        }
        else
        {
            animator.SetBool("walk", false);
        }


        //jump
        //if(Input.GetButtonDown("Jump"))
        if (buttonState == ButtonState.JOYSTICK3 || Input.GetButtonDown("Jump"))
        {
            if (cc.isGrounded)
            {
                Vector3 up = transform.TransformDirection(Vector3.up);

                moveDirection.y = JumpSpeed;
                dJumpCounter = 0;
                animator.SetBool("is_in_air", true);
                //animator.SetTrigger("Jumping");

            }
            if (!cc.isGrounded && dJumpCounter < nrOfAlowedDJumps)
            {
                moveDirection.y = JumpSpeed;
                dJumpCounter++;

            }
        }
        else
        {
            animator.SetBool("is_in_air", false);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
    }

    private void handleKeyboardEvent()
    {
        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            buttonState = ButtonState.JOYSTICK1;
        }
        else if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            buttonState = ButtonState.JOYSTICK2;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            buttonState = ButtonState.JOYSTICK3;
        }
        else if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            buttonState = ButtonState.JOYSTICK0;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button8))
        {
            buttonState = ButtonState.JOYSTICK8;
        }
        else
        {
            buttonState = ButtonState.EMPTY;
        }

    }


    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
        //#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
        //#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            m_GroundNormal = hitInfo.normal;
            //m_IsGrounded = true;
            // m_Animator.applyRootMotion = true;
        }
        else
        {
            //m_IsGrounded = false;
             m_GroundNormal = Vector3.up;
            //m_Animator.applyRootMotion = false;
        }
    }


}
