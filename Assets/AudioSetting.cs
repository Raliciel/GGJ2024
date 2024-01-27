using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    AudioSO set;
    [SerializeField] Slider BGM;
    [SerializeField] Slider SFX;


    private void OnEnable ()
    {
        set = AudioSO.instance;
        BGM.value = set.BGM_value;
        SFX.value = set.SFX_value;
    }

    private void Update()
    {
        set.BGM_value = BGM.value;
        set.SFX_value = SFX.value;
    }
}
