using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BeatingIcon : MonoBehaviour
{
    Image icon => GetComponent<Image>();
    [SerializeField] float beatingTime = 1;
    float _time;

    private void Update()
    {
        if (_time < 0.2f) icon.rectTransform.localScale = Vector3.one * 1.5f;
        else if (_time < 0.5f) icon.rectTransform.localScale = Vector3.one * 1.25f;
        else icon.rectTransform.localScale = Vector3.one;

        if (_time > beatingTime) _time = 0;
        else _time += Time.deltaTime;
    }
}
