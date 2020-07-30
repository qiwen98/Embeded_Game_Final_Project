using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(ChatacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;
    public GameObject[] dealdamageUI;

    ChatacterStats myStats;
    private void Start()
    {
        myStats = GetComponent<ChatacterStats>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public virtual void Attack(ChatacterStats targetStats)
    {
        if(attackCooldown<=0&&targetStats.currentHealth>=0)
        {
            if (dealdamageUI.Length != 0)
            {
              
                int randomindex = UnityEngine.Random.Range(0, dealdamageUI.Length);
                dealdamageUI[randomindex].GetComponent<Text>().text = "x" + myStats.damage.GetValue().ToString() + "dmg";
                dealdamageUI[randomindex].GetComponent<Animator>().SetTrigger("showScore");


            }
            targetStats.takedamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
      
    }
}
