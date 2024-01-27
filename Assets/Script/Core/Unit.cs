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
        if (isDefend)
            return;
        currentHealthPoint -= damage;
        DamageDisplayer.get.ShowHealthDamage(this, damage);
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
        DamageDisplayer.get.ShowAngerDamage(this,anger);
        CheckIfUnitDie(); 
    }

    public bool getIsDefend() { return isDefend; }

    public void setIsDefend(bool isDef) { isDefend = isDef; }

    public void ChangeSprite(CardSO so, PoseCatagory pose)
    {
        StartCoroutine(ChangeandWait(so, PoseCatagory.use));
    }

    [HideInInspector] public bool unoccupied = false;
    protected IEnumerator ChangeandWait(CardSO so, PoseCatagory pose)
    {
        unoccupied = true;
        Sprite oldsprite = GetComponent<SpriteRenderer>().sprite;
        if (gameObject.name.Equals("Player"))
        {
            switch ((int)pose)
            {
                case ((int)(PoseCatagory.use)): GetComponent<SpriteRenderer>().sprite = so.mfUse; break;
                case ((int)(PoseCatagory.react1)): GetComponent<SpriteRenderer>().sprite = so.mfReact1; break;
                case ((int)(PoseCatagory.react2)): GetComponent<SpriteRenderer>().sprite = so.mfReact2; break;
            }

        }
        else
        {
            switch ((int)pose)
            {
                case ((int)(PoseCatagory.use)): GetComponent<SpriteRenderer>().sprite = so.ngUse; break;
                case ((int)(PoseCatagory.react1)): GetComponent<SpriteRenderer>().sprite = so.ngReact1; break;
                case ((int)(PoseCatagory.react2)): GetComponent<SpriteRenderer>().sprite = so.ngReact2; break;
            }

        }

        yield return new WaitForSeconds(0.7f);

        GetComponent<SpriteRenderer>().sprite = oldsprite;
        unoccupied = true;
    }

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
