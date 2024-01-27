using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StayHydrate", menuName = "Card/Defend/StayHydrate", order = 1)]
public class StayHydrate : CardSO
{
    public int angerCost = 15;
    public int hpRecover = 10;
    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null)
    {
        actor.ChangeSprite(this, PoseCatagory.use);
        if(randomized != null) return null;

        actor.payAngerCost(angerCost);
        Debug.Log($"{actor.name} drinks some water to stay hydrate, recover {hpRecover} hp.");
        actor.hpRecover(hpRecover);

        return null;
    }
}