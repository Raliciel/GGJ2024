using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetAudioSound : MonoBehaviour
{
    public static SetAudioSound instance;
    [SerializeField] AudioSource BGMaudio;
    [SerializeField] AudioSource SFXaudio;
    public AudioSO so;

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

    private void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case (0): BGMaudio.clip = so.bgm; break;
            case (1): BGMaudio.clip = so.bgmFight; break;
            case (2): BGMaudio.clip = so.bgmEnd1; break;
            case (3): BGMaudio.clip = so.bgmEnd2; break;
        }

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
