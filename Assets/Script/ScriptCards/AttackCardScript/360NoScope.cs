using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NoScope360", menuName = "Card/Attack/NoScope360", order = 1)]
public class NoScope360 : CardSO
{
    public int damage = 75;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " use 360NoScope.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
