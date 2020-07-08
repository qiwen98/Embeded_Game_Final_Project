using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_SO_Convo : MonoBehaviour
{
    public DialogManager dialogManager;
    public SO_Convo myConvo;
    string Key;
    public GameObject ExclamationMark;
    Animator anim;
    string face_anim;
    string body_anim;
    string idle_anim;
    
    
    
    float ori_speed;
    float temp_speed=5;

    private void Awake()
    {
        Key = myConvo.npcName+"hasmeetPlayer";
        face_anim = myConvo.face_Animation.ToString();
        body_anim = myConvo.body_Animation.ToString();
        idle_anim = myConvo.idle_Animation.ToString();

    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play(idle_anim);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //play defined anim in scriptable obj
            anim.Play(face_anim);
            anim.Play(body_anim);

            dialogManager.Start_dialog(myConvo);


            PlayerPrefs.SetString("MeetBefore", Key);
            ori_speed= other.gameObject.GetComponent<PlayerController>().Speed ;

            //if this npc meet with the player b4
            if (PlayerPrefs.HasKey("MeetBefore"))
            {
                ExclamationMark.SetActive(false);
            }
        }

       
    }

    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(other.transform);

        //reduce the speed of player
        other.gameObject.GetComponent<PlayerController>().Speed =temp_speed;
    }

    private void OnTriggerExit(Collider other)
    {
        dialogManager.StopDialog();

        //restore the speed of player
        other.gameObject.GetComponent<PlayerController>().Speed = ori_speed;
    }


}
