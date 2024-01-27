using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeCouldBeDream", menuName = "Card/Defend/LifeCouldBeDream", order = 1)]
public class LifeCouldBeDream : CardSO
{   
    public int angerCost = 15;
    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        actor.setIsDefend(true);
        Debug.Log($"{actor.name} transform into a cube that can take you to a paradise up above.");
    }
}