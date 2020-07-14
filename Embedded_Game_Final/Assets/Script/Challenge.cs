using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChallengeType
{
    CHALLENGE1
};
public enum ChallengeState
{
    INACTIVE,
    ACTIVE
};
public class Challenge : MonoBehaviour
{
    ChallengeType challengeState;
    public PlayerController plc;

    [Header("Chanllenge1 Essential")]
    public Vector3 challengePosStart;
    public bool isSucess = false;
    public float deathHeigt;
    public Vector3 oriPos;

    public SO_Convo failDialog;
    public SO_Convo successDialog;

    // Start is called before the first frame update
    void Start()
    {
        challengePosStart = new Vector3(10.12f, 14.56f, -65.74f);
        oriPos = plc.transform.position;
        deathHeigt = -5f;
        plc.gameObject.transform.position = challengePosStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void getOriginalPos()
    {
        oriPos = plc.transform.position;
    }

    public void backToOriginalPos()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
