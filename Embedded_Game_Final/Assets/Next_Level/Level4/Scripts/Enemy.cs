using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChatacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    ChatacterStats Enemy_my_Stats; 

    private void Start()
    {
        playerManager = PlayerManager.instance;
        Enemy_my_Stats = GetComponent<ChatacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        //aatack enemy;
        CharacterCombat playercombat = playerManager.player.GetComponent<CharacterCombat>();
        PlayerStats playerhealth = playerManager.player.GetComponent<PlayerStats>();

        if (playercombat!=null&&playerhealth.currentHealth>=0)
        {
            playercombat.Attack(Enemy_my_Stats);
        }

    }
}
