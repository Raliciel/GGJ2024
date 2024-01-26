using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBreaker", menuName = "Card/MonkeBreaker", order = 1)]
public class MonkeBreaker : CardSO
{
    public int damage = 25;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " use MonkeBreaker.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
