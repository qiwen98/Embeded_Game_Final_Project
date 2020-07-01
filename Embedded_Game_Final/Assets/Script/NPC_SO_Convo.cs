using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_SO_Convo : MonoBehaviour
{
    public DialogManager dialogManager;
    public SO_Convo myConvo;
    string Key;
    public GameObject ExclamationMark;
    float ori_speed;
    float temp_speed=5;

    private void Awake()
    {
        Key = myConvo.npcName+"hasmeetPlayer";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           
            dialogManager.Start_dialog(myConvo);


            PlayerPrefs.SetString("MeetBefore", Key);
            ori_speed= other.gameObject.GetComponent<PlayerController>().speed ;

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
        other.gameObject.GetComponent<PlayerController>().speed =temp_speed;
    }

    private void OnTriggerExit(Collider other)
    {
        dialogManager.StopDialog();

        //restore the speed of player
        other.gameObject.GetComponent<PlayerController>().speed = ori_speed;
    }


}
