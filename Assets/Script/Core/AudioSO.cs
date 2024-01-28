using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioSO", menuName = "Audio Listener/Audio SO")]
public class AudioSO : ScriptableObject
{
    public float BGM_value = 0.3f;
    public float SFX_value = 0.5f;

    public AudioClip bgm;
    public AudioClip bgmFight;
    public AudioClip bgmEnd1;
    public AudioClip bgmEnd2;

    public static AudioSO instance;

    public void OnEnable()
    {
        instance = this;
    }
}
