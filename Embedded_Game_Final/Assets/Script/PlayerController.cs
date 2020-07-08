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

    public float Speed = 5.0f;

    public float RotationSpeed = 100.0f;

    public GameObject Hand;

    public float JumpSpeed = 8f;

    public HUD Hud;



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

    public void IncreaseHunger()
    {

    }

    public ButtonState buttonState;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        buttonState = ButtonState.EMPTY;
    }



    private int Punching_1_Hash = Animator.StringToHash("Base Layer.Punching");

    public bool IsAttacking
    {
        get
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.fullPathHash == Punching_1_Hash)
            {
                return true;
            }
            return false;
        }
    }

    private void Update()
    {
        handleWalk();

        handleKeyboardEvent();
        
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    Debug.LogError("Current Key is : " + keyCode.ToString());
                }
            }
        }

        
    }

    public bool IsDead
    {
        get
        {
            return Health == 0 || Food == 0;
        }
    }


    private bool mIsControlEnabled = true;

    public void EnableControl()
    {
        mIsControlEnabled = true;
    }
    public void DisableControl()
    {
        mIsControlEnabled = false;
    }

    private void handleWalk()
    {
        if (!IsDead && mIsControlEnabled)
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
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



        // Move forward / backward
        if (Mathf.Abs(h) >= 0.1f || Mathf.Abs(v) >= 0.1f)
        {
            transform.Rotate(0, h * RotationSpeed, 0);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = Speed * v;
            cc.SimpleMove(forward * curSpeed);
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }


        //jump
        //if(Input.GetButtonDown("Jump")
        if (buttonState == ButtonState.JOYSTICK3)
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
        }else
        {
            buttonState = ButtonState.EMPTY;
        }

    }



}
