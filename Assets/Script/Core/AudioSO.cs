using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "AudioSO", menuName = "Audio Listener/Audio SO")]
public class AudioSO : ScriptableSingleton<AudioSO>
{
    public float BGM_value = 0.5f;
    public float SFX_value = 0.5f;

    public AudioClip bgm;
    public AudioClip bgmFight;
    public AudioClip bgmEnd1;
    public AudioClip bgmEnd2;
}
