using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBall", menuName = "Card/MonkeBall", order = 1)]
public class MonkeBall : CardSO
{
    public int damage = 90;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses MonkeBall.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}