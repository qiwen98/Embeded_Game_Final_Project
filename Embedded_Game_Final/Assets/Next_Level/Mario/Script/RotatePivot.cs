using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePivot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Tweener rotateTW = transform.DOLocalRotate(new Vector3(0f,360f,0f), 3f, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(rotateTW);
        mySequence.SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
