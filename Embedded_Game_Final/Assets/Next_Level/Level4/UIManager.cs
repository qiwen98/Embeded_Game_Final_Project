using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public Slider Health_Silder;
    PlayerManager playerManager;
    PlayerStats playerhealth;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
        Health_Silder.value =(float) PlayerManager.instance.player.GetComponent<PlayerStats>().currentHealth/100;
        Debug.Log((float)PlayerManager.instance.player.GetComponent<PlayerStats>().currentHealth/100);
        Debug.Log(Health_Silder.normalizedValue);
    }

    public void SetMusicVolume()
    {
        
    }
}
