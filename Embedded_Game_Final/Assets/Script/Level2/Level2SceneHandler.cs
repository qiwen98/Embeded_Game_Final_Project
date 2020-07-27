using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2SceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 5;

        QualitySettings.vSyncCount = 0;

        QualitySettings.antiAliasing = 0;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
