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
            if(!unit.IsDied())
                StartCoroutine(EnemyDoAction());
        }
    }

    IEnumerator EnemyDoAction()
    {
        yield return new WaitForSeconds(1);
        BoardManager.get.UseRandomCard();
    }
}
