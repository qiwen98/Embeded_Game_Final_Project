using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    public AudioSource[] bgAudio;
    public AudioSource[] shotAudio;
    public int level;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


    }

    private void Start()
    {
        PlayerBackGroundAudio(level - 1);
    }

    void PlayerBackGroundAudio(int Thelevel)
    {

        bgAudio[Thelevel].Play();
    }

    public void PlayEffectAudio(int sound)
    {
        shotAudio[sound].Play();


    }


}