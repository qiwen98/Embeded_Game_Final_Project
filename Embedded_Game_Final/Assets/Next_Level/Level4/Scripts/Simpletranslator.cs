using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simpletranslator : MonoBehaviour
{
    float timer;
    float timelimit = 5f;
    public AudioClip audioclip;
  public void ObjSlidingDown()
    {
        timer = 0f;
        StartCoroutine("moveDownWard",this.transform.gameObject);
        if(audioclip!=null)
        {
            SoundManager.instance.playsound(audioclip);
        }
        
    }

    public void Update()
    {
        timer += 1 * Time.deltaTime;
    }


    IEnumerator moveDownWard(GameObject obj)
    {
        Debug.Log("event received");
        while (timer<timelimit)
        {


            Debug.Log("moving down");
            obj.transform.Translate(Vector3.down * 0.05f, Space.World);
            yield return new WaitForSeconds(0.01f);
        }


    }

    IEnumerator moveUpward(GameObject player)
    {
        while (timer<timelimit)
        {

            Debug.Log("moving up");

            player.transform.Translate(Vector3.up * 0.05f, Space.World);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void rotating()
    {

        timer = 0f;
        StartCoroutine("startrotate", this.transform.gameObject);

       
    }

    IEnumerator startrotate(GameObject player)
    {
        while(timer<100)
        {
            player.transform.Rotate(Vector3.forward * 1f);
            yield return new WaitForSeconds(0.01f);
        }
        
    }
}
