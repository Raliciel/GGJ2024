using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GigaMonkeBreaker", menuName = "Card/GigaMonkeBreaker", order = 1)]
public class GigaMonkeBreaker : CardSO
{
    public int damage = 50;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " use GigaMonkeBreaker.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
