using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct SlidePart
{
    public Sprite source;
    public float duration;
    public string text;
    public bool doFade;
}


[Serializable]
public struct Slide
{
    public string slideName;
    public SlidePart[] parts;
}

[RequireComponent(typeof(CanvasGroup))]
public class SlideShower : MonoBehaviour
{
    public Slide[] slides;
    private CanvasGroup canvasGroup;

    [Header("Single")]
    public GameObject singleSlide;
    public Image singleSlidePartImage;
    public TextMeshProUGUI singleSlidePartText;

    [Header("Double")]
    public GameObject doubleSlide;
    public Image[] doubleSlidePartImages;
    public TextMeshProUGUI[] doubleSlidePartTexts;

    private bool isSlideReady = false;
    private float nextSlideTime = 0;
    private int nextSlide = 0;
    private int nextPartSlide = 0;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(ShowSlides());
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GoNextSlide();
        }
        if(Time.time > nextSlideTime)
        {
            GoNextSlide();
        }
    }

    IEnumerator ShowSlides()
    {
        canvasGroup.alpha = 0;
        canvasGroup.LeanAlpha(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        isSlideReady = true;
        nextSlide = 0;
        nextPartSlide = 0;
        GoNextSlide();
    }
    void EndSlide()
    {
        Debug.Log("End slide");
        isSlideReady = false;
        canvasGroup.LeanAlpha(0, 0.5f).setDelay(0.5f).setOnComplete(() => { gameObject.SetActive(false); });
    }

    public void OnClickSkip()
    {
        StopAllCoroutines();
        EndSlide();
    }

    void PlaySlide(int slideIndex, int partIndex = 0)
    {
        Debug.Log("Play " + slideIndex + ": " + partIndex);
        Slide slide = slides[slideIndex];

        if (slide.parts.Length > 1)
        {
            doubleSlide.gameObject.SetActive(true);
            singleSlide.gameObject.SetActive(false);

            if (partIndex == 0)
            {
                for (int z = 0; z < slide.parts.Length; z++)
                {
                    doubleSlidePartTexts[z].gameObject.SetActive(false);
                    doubleSlidePartImages[z].gameObject.SetActive(false);
                }
            }

            int j = partIndex;
            SlidePart sp = slide.parts[j];
            doubleSlidePartTexts[j].gameObject.SetActive(true);
            doubleSlidePartImages[j].gameObject.SetActive(true);
            doubleSlidePartTexts[j].text = sp.text;
            doubleSlidePartImages[j].sprite = sp.source;
            nextSlideTime = Time.time + sp.duration;
            nextPartSlide = partIndex + 1;
        }
        else
        {
            doubleSlide.gameObject.SetActive(false);
            singleSlide.gameObject.SetActive(true);
            SlidePart sp = slide.parts[0];
            if (sp.text != "")
                singleSlidePartText.text = sp.text;
            if (sp.source != null)
                singleSlidePartImage.sprite = sp.source;
            nextSlideTime = Time.time + sp.duration;
            nextSlide = slideIndex + 1;
        }
    }

    public void GoNextSlide()
    {
        if (!isSlideReady)
            return;
        if(nextSlide > slides.Length - 1)
        {
            Debug.Log(nextSlide + ", "+slides.Length);
            EndSlide();
            return;
        }
        Debug.Log("Go next slde");
        Slide s = slides[nextSlide];
        if(nextPartSlide > s.parts.Length - 1)
        {
            nextSlide += 1;
            nextPartSlide = 0;
        }
        if (nextSlide > slides.Length - 1)
        {
            Debug.Log(nextSlide + ", " + slides.Length);
            EndSlide();
            return;
        }
        PlaySlide(nextSlide, nextPartSlide);
    }
}
