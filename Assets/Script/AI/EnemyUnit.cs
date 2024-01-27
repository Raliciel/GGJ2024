using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    protected override void Start()
    {
        base.Start();
        Turn.get.OnChangeTurn += OnChangeTurn;
    }

    void OnChangeTurn(Unit unit)
    {
        if(unit == this )
        {
            //Is not die
            if(unit.GetCurrentHealthPoint() > 0 && unit.GetCurrentAngerPoint() > 0)
                StartCoroutine(EnemyDoAction());
        }
    }

    IEnumerator EnemyDoAction()
    {
        yield return new WaitForSeconds(1);
        BoardManager.get.UseRandomCard();
    }
}
