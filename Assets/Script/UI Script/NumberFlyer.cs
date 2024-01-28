using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberFlyer : MonoBehaviour
{
    CanvasGroup textCanvasGroup;

    private void Start()
    {
        textCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void FlyToLeft()
    {
        if (textCanvasGroup == null) textCanvasGroup = GetComponent<CanvasGroup>();
        LeanTween.moveLocal(gameObject, transform.localPosition + new Vector3(-120f, 210f), .5f).setEase(LeanTweenType.easeInOutQuad);
        textCanvasGroup.LeanAlpha(0f, 1f).setEase(LeanTweenType.easeInOutQuad).setDestroyOnComplete(true);
    }

    public void FlyToRight()
    {
        if (textCanvasGroup == null) textCanvasGroup = GetComponent<CanvasGroup>();
        LeanTween.moveLocal(gameObject, transform.localPosition + new Vector3(120f, 210f), .5f).setEase(LeanTweenType.easeInOutQuad);
        textCanvasGroup.LeanAlpha(0f, 1f).setEase(LeanTweenType.easeInOutQuad).setDestroyOnComplete(true);
    }
}
