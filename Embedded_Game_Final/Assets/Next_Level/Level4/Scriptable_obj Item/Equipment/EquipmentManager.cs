using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region singleton

    public static EquipmentManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
        
    public OnEquipmentChanged onEquipmentChanged;
    public AudioClip equipsound;
    public GameObject bow;
    public GameObject sword;
    Equipment[] CurrentEquipment;
    Inventory invetory;
    
    // Start is called before the first frame update
    void Start()
    {
        invetory = Inventory.instance;
        int  numslots=System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        CurrentEquipment = new Equipment[numslots];
    }

    public void Equip (Equipment new_item)
    {
        int slotIndex = (int)new_item.EquipSlot;

        SoundManager.instance.playsound(equipsound);
        //if new_item.name is bow, then set the bow active true
        if(slotIndex==3&&new_item.name=="Bow")
        {
            bow.SetActive(true);
        }
        else if(slotIndex == 3 && new_item.name == "Sword")
        {
            sword.SetActive(true);
        }
        
        //in the bow, place the bullet 

        Equipment Old_Item = null;
        if(CurrentEquipment[slotIndex]!=null)
        {
            Old_Item = CurrentEquipment[slotIndex];
            //if the olditem.name is bow, set bow active false
            if (slotIndex == 3 && Old_Item.name == "Bow")
            {
                bow.SetActive(false);
            }
            else if (slotIndex == 3 && Old_Item.name == "Sword")
            {
                sword.SetActive(false);
            }

            invetory.Add(Old_Item);
        }

        if(onEquipmentChanged!=null)
        {
            onEquipmentChanged(new_item, Old_Item);
        }

        CurrentEquipment[slotIndex] = new_item;
    }

    public void UnEquip(int slotIndex)
    {


        if (CurrentEquipment[slotIndex]!=null)
        {
           
            Equipment oldItem = CurrentEquipment[slotIndex];
           


            invetory.Add(oldItem);

            CurrentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged(null, oldItem);
            }
        }

       
    }

    public void UnEquipAll()
    {
        bow.SetActive(false);
        sword.SetActive(false);
        for (int i=0;i<CurrentEquipment.Length;i++)
        {
            UnEquip(i);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }
}
