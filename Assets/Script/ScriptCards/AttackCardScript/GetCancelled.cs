using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GetCancelled", menuName = "Card/GetCancelled", order = 1)]
public class GetCancelled : CardSO
{
    public int damage = 50;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses GetCancelled.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
