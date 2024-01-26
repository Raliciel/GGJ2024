using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeCouldBeDream", menuName = "Card/LifeCouldBeDream", order = 1)]
public class LifeCouldBeDream : CardSO
{
    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses Life could be dream.");
    }
}