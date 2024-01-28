using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "AudioSO", menuName = "Audio Listener/Audio SO")]
public class AudioSO : ScriptableSingleton<AudioSO>
{
    public float BGM_value = 0.3f;
    public float SFX_value = 0.8f;
}
