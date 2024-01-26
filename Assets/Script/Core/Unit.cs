using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int healthPoint = 100;
    [SerializeField] protected int currentHealthPoint;
    public int angerPoint = 100;
    [SerializeField] protected int currentAngerPoint;

    bool isDefend;

    SpriteRenderer _renderer;

    protected virtual void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        ResetState();
    }

    private void ResetState()
    {   
        isDefend = false;
        currentHealthPoint = healthPoint;
        currentAngerPoint = angerPoint;
    }

    void Update()
    {
        if (Turn.get.GetCurrentUnit() == this)
           _renderer.color = Color.red;
        else
           _renderer.color = Color.white;
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
    
    public void payAngerCost(int angerCost) {
        currentAngerPoint -= angerCost;
    }

    public void receivedDamage(int damage) {
        if(!isDefend) currentHealthPoint -= damage;
    }

    public void receivedAnger(int anger) {
        currentAngerPoint += anger;
        if(currentAngerPoint > angerPoint) currentAngerPoint = angerPoint;
    }

    public bool getIsDefend() {
        return isDefend;
    }

    public void setIsDefend(bool isDef) {
        isDefend = isDef;
    }

}
