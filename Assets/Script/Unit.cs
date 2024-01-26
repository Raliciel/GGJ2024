using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int healthPoint;
    [SerializeField] protected int currentHealthPoint;
    public int angerPoint;
    [SerializeField] protected int currentAngerPoint;
    // Update is called once per frame
    void Update()
    {
        if (Turn.GetCurrentUnit().gameObject.name.Equals(gameObject.name))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public int GetCurrentHealthPoint()
    {
        return currentHealthPoint;
    }

    public int GetCurrentAngerPoint()
    {
        return currentAngerPoint;
    }

    public void SetCurrentHealthPoint(int hp) {
        currentHealthPoint = hp;
    }

    public void SetCurrentAngerPoint(int ap) {
        currentAngerPoint = ap;
    }
}
