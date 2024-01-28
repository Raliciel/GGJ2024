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

    public void OnEnable()
    {
        bgm = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sound/questionablepadthai.mp3");
        bgmFight = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sound/primitiveangery.mp3");
        bgmEnd1 = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sound/nofight.mp3");
        bgmEnd2 = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sound/nofriend.mp3");
    }
}
