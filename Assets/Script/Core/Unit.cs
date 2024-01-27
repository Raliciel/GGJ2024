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
    public int GetCurrentHealthPoint() { return currentHealthPoint; }

    public int GetCurrentAngerPoint() { return currentAngerPoint; }

    public void SetCurrentHealthPoint(int hp) { currentHealthPoint = hp; }

    public void SetCurrentAngerPoint(int ap) { currentAngerPoint = ap; }
    
    public void payAngerCost(int angerCost) { currentAngerPoint -= angerCost; }

    public void payHPCost(int hpCost) { currentHealthPoint -= hpCost; }

    public void receivedDamage(int damage) { if(!isDefend) currentHealthPoint -= damage; }

    public void hpRecover(int recover) {
        currentHealthPoint += recover;
        if(currentHealthPoint > healthPoint) currentHealthPoint = healthPoint;
    }

    public void receivedAnger(int anger) {
        currentAngerPoint += anger;
        if(currentAngerPoint > angerPoint) currentAngerPoint = angerPoint;
    }

    public void reducedAnger(int anger) { currentAngerPoint -= anger; }

    public bool getIsDefend() { return isDefend; }

    public void setIsDefend(bool isDef) { isDefend = isDef; }

    public void ChangeSprite(CardSO so, PoseCatagory pose)
    {
        StartCoroutine(ChangeandWait(so, PoseCatagory.use));
    }

    protected IEnumerator ChangeandWait(CardSO so, PoseCatagory pose)
    {
        Sprite oldsprite = GetComponent<SpriteRenderer>().sprite;
        if (gameObject.name.Equals("Player"))
        {
            switch ((int)pose)
            {
                case ((int)(PoseCatagory.use)): GetComponent<SpriteRenderer>().sprite = so.ngUse; break;
                case ((int)(PoseCatagory.react1)): GetComponent<SpriteRenderer>().sprite = so.ngReact1; break;
                case ((int)(PoseCatagory.react2)): GetComponent<SpriteRenderer>().sprite = so.ngReact2; break;
            }
        }
        else
        {
            switch ((int)pose)
            {
                case ((int)(PoseCatagory.use)): GetComponent<SpriteRenderer>().sprite = so.mfUse; break;
                case ((int)(PoseCatagory.react1)): GetComponent<SpriteRenderer>().sprite = so.mfReact1; break;
                case ((int)(PoseCatagory.react2)): GetComponent<SpriteRenderer>().sprite = so.mfReact2; break;
            }
        }

        yield return new WaitForSeconds(0.7f);

        GetComponent<SpriteRenderer>().sprite = oldsprite;
    }

}
