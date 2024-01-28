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

    bool isDefending;
    bool isDied;

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
        isDefending = false;
    }

    public void ResetStats()
    {
        isDied = false;
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
    
    public void PayAngerCost(int angerCost) {
        currentAngerPoint -= angerCost;
        if (currentAngerPoint < 0)
            currentAngerPoint = 1;
        CheckIfUnitDie();
    }

    public void PayHPCost(int hpCost) {
        currentHealthPoint -= hpCost;
        if (currentHealthPoint < 0)
            currentHealthPoint = 1;
        CheckIfUnitDie();
    }

    public void DelayedReduceHP(int amount, float delay)
    {
        StartCoroutine(ReduceHPRoutine(amount, delay));
    }
    public void DelayedRecoverHP(int amount, float delay)
    {
        StartCoroutine(RecoverHPRoutine(amount, delay));
    }
    public void DelayedReduceAnger(int amount, float delay)
    {
        StartCoroutine(ReduceAngerRoutine(amount, delay));
    }
    public void DelayedRecoverAnger(int amount, float delay)
    {
        StartCoroutine(RecoverAngerRoutine(amount,delay));
    }

    IEnumerator ReduceHPRoutine(int damage, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReduceHP(damage);
    }
    IEnumerator RecoverHPRoutine(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        RecoverHP(amount);
    }
    IEnumerator ReduceAngerRoutine(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReduceAnger(amount);
    }
    IEnumerator RecoverAngerRoutine(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);
        RecoverAnger(amount);
    }

    public void ReduceHP(int damage) {
        if (isDefending)
            return;
        currentHealthPoint -= damage;
        DamageDisplayer.get.ShowHealthDamage(this, damage, Color.red);
        CheckIfUnitDie();
    }

    public void ReduceAnger(int anger)
    {
        currentAngerPoint -= anger;
        DamageDisplayer.get.ShowAngerDamage(this, anger, Color.blue);
        CheckIfUnitDie();
    }


    public void RecoverHP(int recover) {
        currentHealthPoint += recover;
        DamageDisplayer.get.ShowHealthDamage(this, recover, Color.green);
        if (currentHealthPoint > healthPoint) 
            currentHealthPoint = healthPoint;
        CheckIfUnitDie();
    }

    public void RecoverAnger(int anger) {
        currentAngerPoint += anger;
        DamageDisplayer.get.ShowAngerDamage(this, anger, new Color(1, 0.2f, 0));
        if (currentAngerPoint > angerPoint) 
            currentAngerPoint = angerPoint;
        CheckIfUnitDie();
    }

    public bool IsDefending() { return isDefending; }

    public void SetDefendState(bool isDef) { isDefending = isDef; }

    public void ChangeSprite(CardSO so, PoseCatagory pose, float duration = 1, float delay = 0)
    {
        StartCoroutine(ChangeandWait(so, pose, duration, delay));
    }

    [HideInInspector] public bool unoccupied = false;
    protected IEnumerator ChangeandWait(CardSO so, PoseCatagory pose, float duration, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Pose: " + pose);
        Sprite oldsprite = _renderer.sprite;
        unoccupied = true;
        if (gameObject.name.Equals("Player"))
        {
            switch (pose)
            {
                case PoseCatagory.use: _renderer.sprite = so.mfUse; break;
                case PoseCatagory.react1: _renderer.sprite = so.mfReact1; break;
                case PoseCatagory.react2: _renderer.sprite = so.mfReact2; break;
            }

        }
        else if (gameObject.name.Equals("Enemy"))
        {
            switch (pose)
            {
                case PoseCatagory.use: _renderer.sprite = so.ngUse; break;
                case PoseCatagory.react1: _renderer.sprite = so.ngReact1; break;
                case PoseCatagory.react2: _renderer.sprite = so.ngReact2; break;
            }

        }

        yield return new WaitForSeconds(duration);

        _renderer.sprite = oldsprite;
        unoccupied = true;
    }

    public bool IsDied()
    {
        return isDied;
    }

    private void CheckIfUnitDie()
    {
        if (IsDied())
            return;
        if (currentHealthPoint <= 0)
        {
            isDied = true;
            currentHealthPoint = 0;
            OnDeath?.Invoke();
            return;
        }
        if (currentAngerPoint <= 0)
        {
            isDied = true;
            currentAngerPoint = 0;
            OnLaugh?.Invoke();
        }
    }
}
