using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BritishAccent", menuName = "Card/BritishAccent", order = 1)]
public class BritishAccent : CardSO
{
    public int damage = 20;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses BritishAccent.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
