using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarTarget
{
    health,
    anger
}

public class ShowBarInfo : MonoBehaviour
{
    [SerializeField] Unit target;
    [SerializeField] BarTarget barTarget;
    [SerializeField] Gradient colorGradient;
    [SerializeField] float easeSpeed = 5f;

    [SerializeField] private Image mainBar;
    [SerializeField] private Image follwerBar;

 
    // Update is called once per frame
    void Update()
    {
        float targetValue = 0;
        if ((int)barTarget == (int)BarTarget.health)
        {
            targetValue = target.GetCurrentHealthPoint() / (float)target.healthPoint;
        }

        else if ((int)barTarget == (int)BarTarget.anger)
        {
            targetValue = target.GetCurrentAngerPoint() / (float)target.angerPoint;
        }
        if (mainBar)
        {
            mainBar.color = colorGradient.Evaluate(mainBar.fillAmount);
            mainBar.fillAmount = Mathf.Lerp(mainBar.fillAmount, targetValue, Time.deltaTime * easeSpeed);
        }
        if (follwerBar)
        {
            if(targetValue > mainBar.fillAmount)
            {
                follwerBar.fillAmount = Mathf.Lerp(follwerBar.fillAmount, targetValue, Time.deltaTime * easeSpeed *3);
            }
            else
            {
                follwerBar.fillAmount = Mathf.Lerp(follwerBar.fillAmount, targetValue, Time.deltaTime * easeSpeed / 3);
            }
        }
    }
}
