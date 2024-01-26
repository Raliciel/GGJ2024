using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ApeWMG", menuName = "Card/ApeWMG", order = 1)]
public class ApeWMG : CardSO
{
    public int damage = 60;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses Ape with Machine Gun.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
