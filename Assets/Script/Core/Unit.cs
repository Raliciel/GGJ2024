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
        if (currentAngerPoint < 0)
            currentAngerPoint = 1;
        CheckIfUnitDie();
    }

    public void payHPCost(int hpCost) {
        currentHealthPoint -= hpCost;
        if (currentHealthPoint < 0)
            currentHealthPoint = 1;
        CheckIfUnitDie();
    }

    public void receivedDamage(int damage) {
        if (isDefend)
            return;
        currentHealthPoint -= damage;
        DamageDisplayer.get.ShowHealthDamage(this, damage, Color.red);
        CheckIfUnitDie();
    }

    public void hpRecover(int recover) {
        currentHealthPoint += recover;
        DamageDisplayer.get.ShowHealthDamage(this, recover, Color.green);
        if (currentHealthPoint > healthPoint) 
            currentHealthPoint = healthPoint;
        CheckIfUnitDie();
    }

    public void receivedAnger(int anger) {
        currentAngerPoint += anger;
        DamageDisplayer.get.ShowAngerDamage(this, anger, new Color(1, 0.2f, 0));
        if (currentAngerPoint > angerPoint) 
            currentAngerPoint = angerPoint;
        CheckIfUnitDie();
    }

    public void reducedAnger(int anger) { 
        currentAngerPoint -= anger;
        DamageDisplayer.get.ShowAngerDamage(this,anger,Color.blue);
        CheckIfUnitDie(); 
    }

    public bool getIsDefend() { return isDefend; }

    public void setIsDefend(bool isDef) { isDefend = isDef; }

    public void ChangeSprite(CardSO so, PoseCatagory pose)
    {
        StartCoroutine(ChangeandWait(so, pose));
    }

    [HideInInspector] public bool unoccupied = false;
    protected IEnumerator ChangeandWait(CardSO so, PoseCatagory pose)
    {
        Debug.Log("Pose: " + pose);
        Sprite oldsprite = GetComponent<SpriteRenderer>().sprite;
        unoccupied = true;
        if (gameObject.name.Equals("Player"))
        {
            switch ((int)pose)
            {
                case ((int)PoseCatagory.use): GetComponent<SpriteRenderer>().sprite = so.mfUse; break;
                case ((int)PoseCatagory.react1): GetComponent<SpriteRenderer>().sprite = so.mfReact1; break;
                case ((int)PoseCatagory.react2): GetComponent<SpriteRenderer>().sprite = so.mfReact2; break;
            }

        }
        else if (gameObject.name.Equals("Enemy"))
        {
            switch ((int)pose)
            {
                case ((int)PoseCatagory.use): GetComponent<SpriteRenderer>().sprite = so.ngUse; break;
                case ((int)PoseCatagory.react1): GetComponent<SpriteRenderer>().sprite = so.ngReact1; break;
                case ((int)PoseCatagory.react2): GetComponent<SpriteRenderer>().sprite = so.ngReact2; break;
            }

        }

        yield return new WaitForSeconds(0.7f);

        GetComponent<SpriteRenderer>().sprite = oldsprite;
        DialogueSystem.CloseLog();
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
