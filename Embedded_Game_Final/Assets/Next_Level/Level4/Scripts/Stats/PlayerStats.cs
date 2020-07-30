using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ChatacterStats
{
   
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChange;
    }

   

    void OnEquipmentChange(Equipment newitem,Equipment olditem)
    {
        if(newitem!=null)
        {
            armor.Addmodifier(newitem.armorModifier);
            damage.Addmodifier(newitem.damageModifier);
            //if new item is meelee. then play melee animation
            //if new item is range. play range aniamtion
        }

        if (olditem != null)
        {
            armor.Removemodifier(olditem.armorModifier);
            damage.Removemodifier(olditem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("Die");
        Invoke("reload", 2f);
        
    }

    public void reload()
    {
        PlayerManager.instance.KillPlayer();
    }


}
