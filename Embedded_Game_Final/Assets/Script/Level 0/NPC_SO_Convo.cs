﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_SO_Convo : MonoBehaviour
{
    public DialogManager dialogManager;
    public SO_Convo myConvoOri;
    string Key;
    public GameObject ExclamationMark;
    Animator anim;
    string face_anim;
    string body_anim;
    string idle_anim;

    float ori_speed;
    float temp_speed = 5;

    // public NPC_SO_Convo npcStateSetter;
    // public SO_Convo myConvoSuccess;

    public float ori_camDis;
    public float temp_camDis = 2f;

    private void Awake()
    {

        Key = myConvoOri.npcName + "hasmeetPlayer";
        face_anim = myConvoOri.face_Animation.ToString();
        body_anim = myConvoOri.body_Animation.ToString();
        idle_anim = myConvoOri.idle_Animation.ToString();
        myConvoOri.reset();

    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play(idle_anim);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ori_camDis = other.GetComponent<PlayerController>().cam.controlZ;
            //play defined anim in scriptable obj
            anim.Play(face_anim);
            anim.Play(body_anim);

            dialogManager.Start_dialog(myConvoOri);


            PlayerPrefs.SetString("MeetBefore", Key);
            //ori_speed = other.gameObject.GetComponent<PlayerController>().Speed;

            //if this npc meet with the player b4
            if (PlayerPrefs.HasKey("MeetBefore"))
            {
                ExclamationMark.SetActive(false);
            }
        }


    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<PlayerController>().cam.controlZ = temp_camDis;

        transform.LookAt(other.transform);

        //reduce the speed of player
        //other.gameObject.GetComponent<PlayerController>().Speed = temp_speed;

        handleNextButton(other);

    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerController>().cam.controlZ = ori_camDis;

        dialogManager.StopDialog();

        //restore the speed of player
       // other.gameObject.GetComponent<PlayerController>().Speed = ori_speed;
    }

    private void handleNextButton(Collider other)
    {
        PlayerController plc = other.GetComponent<PlayerController>();
        if (plc.cam.NextButton.Pressed && Utility.instance.handleKeyBoardEvent())
        {
            dialogManager.Next();
            Utility.instance.currTime = Time.frameCount;
        }
    }

}
