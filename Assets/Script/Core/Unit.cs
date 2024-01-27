using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public int healthPoint = 100;
    [SerializeField] protected int currentHealthPoint;
    public int angerPoint = 100;
    [SerializeField] protected int currentAngerPoint;

    bool isDefend;

    public UnityAction OnDeath;
    public UnityAction OnLaugh;
    SpriteRenderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<SpriteRenderer>();
        Turn.get.OnChangeTurn += OnChangeTurn;
    }

    private void OnDisable()
    {
        Turn.get.OnChangeTurn -= OnChangeTurn;
    }

    protected virtual void Start()
    {
    }

    void OnChangeTurn(Unit unit)
    {
        if (unit == this)
        {
            ResetState();
            _renderer.color = Color.red;
        }
        else
            _renderer.color = Color.white;
    }

    public void ResetState()
    {   
        isDefend = false;
    }

    public void ResetStats()
    {
        currentHealthPoint = healthPoint;
        currentAngerPoint = angerPoint;
    }


    public int GetCurrentHealthPoint() { return currentHealthPoint; }

    public int GetCurrentAngerPoint() { return currentAngerPoint; }

    public void SetCurrentHealthPoint(int hp) {
        currentHealthPoint = hp;
        CheckIfUnitDie();
    }

    public void SetCurrentAngerPoint(int ap) {
        currentAngerPoint = ap;
        CheckIfUnitDie();
    }
    
    public void payAngerCost(int angerCost) {
        currentAngerPoint -= angerCost;
        CheckIfUnitDie();
    }

    public void payHPCost(int hpCost) {
        currentHealthPoint -= hpCost;
        CheckIfUnitDie();
    }

    public void receivedDamage(int damage) { 
        if(!isDefend) 
            currentHealthPoint -= damage;
        CheckIfUnitDie();
    }

    public void hpRecover(int recover) {
        currentHealthPoint += recover;
        if(currentHealthPoint > healthPoint) 
            currentHealthPoint = healthPoint;
        CheckIfUnitDie();
    }

    public void receivedAnger(int anger) {
        currentAngerPoint += anger;
        if(currentAngerPoint > angerPoint) 
            currentAngerPoint = angerPoint;
        CheckIfUnitDie();
    }

    public void reducedAnger(int anger) { 
        currentAngerPoint -= anger; 
        CheckIfUnitDie(); 
    }

    public bool getIsDefend() { return isDefend; }

    public void setIsDefend(bool isDef) { isDefend = isDef; }

    private void CheckIfUnitDie()
    {
        if (currentHealthPoint <= 0)
        {
            currentHealthPoint = 0;
            OnDeath?.Invoke();
            return;
        }
        if (currentAngerPoint <= 0)
        {
            currentAngerPoint = 0;
            OnLaugh?.Invoke();
        }
    }
}
