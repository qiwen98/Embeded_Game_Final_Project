using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBrick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine("Fall");
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        transform.DOMoveY(-50f, 6f);
    }
}
