using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageDisplayer : MonoBehaviour
{
    public GameObject damagePref;
    public Canvas canvas;
    private Camera cam;

    private static DamageDisplayer _instance;
    public static DamageDisplayer get => _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        cam = Camera.main;
    }

    public void ShowHealthDamage(Unit target,int amount, Color color)
    { 
        TextMeshProUGUI textNumber = DisplayText(amount.ToString(), cam.WorldToScreenPoint(target.transform.position), color);
        NumberFlyer nf = textNumber.GetComponent<NumberFlyer>();
        if (nf != null )
        {
            if (target == GameManager.get.playerUnit)
                nf.FlyToLeft();
            else
                nf.FlyToRight();
        }
    }
    public void ShowAngerDamage(Unit target, int amount, Color color)
    {
        TextMeshProUGUI textNumber = DisplayText(amount.ToString(), cam.WorldToScreenPoint(target.transform.position),color);
        NumberFlyer nf = textNumber.GetComponent<NumberFlyer>();
        if (target == GameManager.get.playerUnit)
            nf.FlyToRight();
        else
            nf.FlyToLeft();
    }

    private TextMeshProUGUI DisplayText(string text, Vector3 pos, Color color)
    {
        TextMeshProUGUI textNumber = Instantiate(damagePref.gameObject, canvas.transform).GetComponent<TextMeshProUGUI>();
        textNumber.transform.position = pos;
        textNumber.text = text;
        textNumber.color = color;
        return textNumber;
    }
}
