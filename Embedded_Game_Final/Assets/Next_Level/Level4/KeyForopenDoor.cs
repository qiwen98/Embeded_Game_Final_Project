using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForopenDoor : MonoBehaviour
{
    public GameEvent OpenGate1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("event raist");
            OpenGate1.Raise();
        }
    }
}
