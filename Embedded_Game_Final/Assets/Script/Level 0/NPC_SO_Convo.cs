using System.Collections;
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
    float temp_speed=1f;

   // public NPC_SO_Convo npcStateSetter;
   // public SO_Convo myConvoSuccess;

    private void Awake()
    {

        Key = myConvoOri.npcName+"hasmeetPlayer";
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
        if(other.CompareTag("Player"))
        {
            //play defined anim in scriptable obj
            anim.Play(face_anim);
            anim.Play(body_anim);

            dialogManager.Start_dialog(myConvoOri);


            PlayerPrefs.SetString("MeetBefore", Key);
            ori_speed= other.gameObject.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier;

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
        other.gameObject.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = temp_speed;

        handleNextButton();

    }

    private void OnTriggerExit(Collider other)
    {
        dialogManager.StopDialog();

        //restore the speed of player
        other.gameObject.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = ori_speed;
    }

    private void handleNextButton()
    {
        if(Utility.instance.handleKeyBoardEvent()&&Input.GetKey(KeyCode.C))
        {
            dialogManager.Next();
            Utility.instance.currTime = Time.frameCount;
        }
    }

}
