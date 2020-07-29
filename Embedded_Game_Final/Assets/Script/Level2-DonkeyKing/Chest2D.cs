﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Chest2D : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            obj.GetComponent<PlayableDirector>().enabled = true;
            Camera.main.GetComponent<CameraFilterPack_Color_GrayScale>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
