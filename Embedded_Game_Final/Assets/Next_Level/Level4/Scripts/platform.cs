using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public GameObject thePlatfrom;
    public GameObject thePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlatfrom = transform.parent.gameObject;
        thePlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.parent = thePlatfrom.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        thePlayer.transform.parent = null;
    }
}
