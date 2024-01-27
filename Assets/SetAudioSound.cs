using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetAudioSound : MonoBehaviour
{
    static SetAudioSound instance;
    [SerializeField] AudioSource BGMaudio;
    [SerializeField] AudioSource SFXaudio;
    AudioSO so;

    public void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null) instance = this;
        else Destroy(gameObject);
        so = AudioSO.instance;
    }
    public void Update()
    {
        BGMaudio.volume = so.BGM_value;
        SFXaudio.volume = so.SFX_value;
    }

    public void ChangeBGM(AudioClip clip)
    {
        BGMaudio.clip = clip;
        BGMaudio.Play();
    }

    public void StopBGM()
    {
        BGMaudio.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXaudio.clip = clip;
        SFXaudio.Play();
    }
}
