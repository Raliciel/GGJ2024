using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarTarget
{
    health,
    anger
}

[RequireComponent(typeof(Slider))]
public class ShowBarInfo : MonoBehaviour
{
    [SerializeField] Unit target;
    [SerializeField] BarTarget barTarget;
    Slider bar => GetComponent<Slider>();
    // Update is called once per frame
    void Update()
    {
        if ((int)barTarget == (int)BarTarget.health)
        {
            bar.maxValue = target.healthPoint;
            bar.value = target.GetCurrentHealthPoint();
        }

        else if ((int)barTarget == (int)BarTarget.anger)
        {
            bar.maxValue = target.angerPoint;
            bar.value = target.GetCurrentAngerPoint();
        }
    }
}
