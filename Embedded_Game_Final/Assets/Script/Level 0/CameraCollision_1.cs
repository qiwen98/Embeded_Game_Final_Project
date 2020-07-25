using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision_1 : MonoBehaviour
{

    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;

    public float dis_ray;

    public Transform playerPosition;
    // Use this for initialization
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        Debug.Log(desiredCameraPos);
        */
        RaycastHit hit;

        Vector3 desirePos = transform.parent.TransformPoint(new Vector3(0f, 0f, 2.3f));
        Debug.Log(desirePos);
        if (Physics.Linecast(transform.parent.position, desirePos, out hit))
        {
            Debug.Log("??");
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, 0f, 2.3f), Time.deltaTime * smooth);

        }
        else
        {
            Debug.Log("!!");
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime * smooth);
        }
        /*
        Debug.Log(dollyDir * distance);
        Debug.Log(transform.localPosition);
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime);
        */
    }
}