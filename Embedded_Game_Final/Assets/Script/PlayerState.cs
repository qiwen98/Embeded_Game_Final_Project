using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerFaceState
{
    WEIQU,// 委屈
    DESE,//嘚瑟
    FENNU,//愤怒
    CHIJING,//吃惊
    JUSANG, //沮丧
    KAIXIN
}

public enum PlayerMoveState
{
    IDLE,
    WALKING,
    RUNNING
}
public enum PlayerActionState
{
    IDLE,
    HOLDING,
    ATTACKING
}