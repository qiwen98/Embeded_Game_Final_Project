using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
      if(  collision.collider.CompareTag("MovingPlatform"))
         {
            PlayerMoveQw playermove = GetComponent<PlayerMoveQw>();
            playermove.slopeLimit = 0;
        }

        if (collision.collider.CompareTag("Death"))
        {
            transform.position = startPos;
            transform.rotation = startRot;
            GetComponentInChildren<Animator>().Play("Defeat",-1,0f);
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);

        }

        if(collision.collider.CompareTag("CheckPoint"))
        {
            startPos= collision.collider.gameObject.transform.position;
            startRot= collision.collider.gameObject.transform.rotation;
            Destroy(collision.collider.gameObject);
        }
    }
}
