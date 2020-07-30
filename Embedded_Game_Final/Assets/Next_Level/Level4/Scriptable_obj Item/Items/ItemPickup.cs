using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public AudioClip pickupsound;

    public override void Interact()
    {
        base.Interact();

        PickUP();
    }

    void PickUP()
    {
        Debug.Log("Picking up item"+item.name);
        bool wasPickedUp=Inventory.instance.Add(item);
        if(pickupsound!=null)
        {
            SoundManager.instance.playsound(pickupsound);
        }
        

        if(wasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }
}
