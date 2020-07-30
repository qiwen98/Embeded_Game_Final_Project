using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    #region singleton

    public static SoundManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion
    AudioSource audio;
    public AudioClip[] playersound;
    public AudioSource[] myMusic;
    public AudioSource[] mySFX;

    public AudioMixerGroup musicMixer, SfxMixer;
    public Slider musicSlider, SfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume()
    {
        musicMixer.audioMixer.SetFloat("MusicParam", musicSlider.value);
    }

    public void SetSfxVolume()
    {
        SfxMixer.audioMixer.SetFloat("SfxParam", SfxSlider.value);
    }

    public void PlaySFX(int sound)
    {
        mySFX[sound].Play();
    }

    public void StopMusic(int Thelevel)
    {
        myMusic[Thelevel - 1].Stop();
    }

    public void playsound(AudioClip soundclip)
    {
        audio.PlayOneShot(soundclip);
    }
}
