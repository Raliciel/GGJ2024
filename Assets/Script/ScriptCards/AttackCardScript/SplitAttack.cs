using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SplitAttack", menuName = "Card/SplitAttack", order = 1)]
public class SplitAttack : CardSO
{
    public int damage = 20;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses SplitAttack.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
