using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_SO_Convo : MonoBehaviour
{
    public DialogManager dialogManager;
    public SO_Convo myConvo;
    string Key;
    public GameObject ExclamationMark;

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
    }

 

  
}
