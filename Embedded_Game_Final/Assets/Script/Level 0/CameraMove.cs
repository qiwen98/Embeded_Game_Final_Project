using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责相机跟随的类
/// </summary>
public class CameraMove : MonoBehaviour
{
    public Transform mainCharacter;

    Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        diff = transform.position - mainCharacter.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainCharacter.position+diff;
    }
}
