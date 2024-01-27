using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeCouldBeDream", menuName = "Card/Defend/LifeCouldBeDream", order = 1)]
public class LifeCouldBeDream : CardSO
{   
    public int angerCost = 15;
    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null)
    {
        actor.ChangeSprite(this, PoseCatagory.use);
        enemy.ChangeSprite(this, PoseCatagory.react1);
        if (randomized != null) return null;

        actor.payAngerCost(angerCost);
        actor.setIsDefend(true);
        DialogueSystem.Log($"{actor.name} transform into a cube that can take you to a paradise up above.");

        return null;
    }
}