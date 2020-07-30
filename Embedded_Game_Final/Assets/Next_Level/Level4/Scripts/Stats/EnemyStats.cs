using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : ChatacterStats
{
    public Slider Health_Silder;
    public GameObject Loot;

    public override void Die()
    {
        base.Die();

        // add death animation
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("Die");
        Invoke("SelfDestroy", 3f);
       
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
        if(Loot!=null)
        {
            Instantiate(Loot, this.transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (Health_Silder!=null)
        {
            EnemyStats enemyStats = GetComponent<EnemyStats>();
            Health_Silder.value =(enemyStats.currentHealth / enemyStats.maxHealth);
        }
       
      
       
    }

}
