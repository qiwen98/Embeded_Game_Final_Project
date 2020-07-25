using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Utility instance;

    public int currTime;
    private void Awake()
    {
        currTime = 0;
        instance = this;
    }
    //处理键盘事件，某些键盘事件间隔不能低于60帧
    public bool handleKeyBoardEvent()
    {
        return Time.frameCount - currTime > 30;
    }
}
