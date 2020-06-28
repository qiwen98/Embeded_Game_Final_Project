using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制玩家行动的类
/// </summary>
/// 

public class PlayerController : MonoBehaviour
{
    
    [Header("Character Attribute")]
    public float speed = 12f;
    public PlayerFaceState faceState;
    public PlayerMoveState moveState;
    public PlayerActionState actionState;




    private CharacterController cc;
    private Transform camTrans;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        moveHandler();
    }
    private void LateUpdate()
    {
        rotationHandler();
    }

    void rotationHandler()
    {
        camTrans = Camera.main.transform;
        Quaternion camQua = new Quaternion(
            camTrans.rotation.x, camTrans.rotation.y, camTrans.rotation.z, camTrans.rotation.w);
        camQua.x = 0f; camQua.z = 0f;
        transform.rotation = Quaternion.Lerp(transform.rotation, camQua, Time.deltaTime * 10f);
    }

    void moveHandler()
    {
        camTrans = Camera.main.transform;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if ((Mathf.Abs(x) > 0.1f) || Mathf.Abs(z) > 0.1f)
        {
            //处理人物行走
            Vector3 direction = camTrans.forward * z + camTrans.right * x;
            direction.y = 0f;
            Vector3 distance = direction * speed * Time.deltaTime;
            cc.Move(distance);
        }
    }
}
