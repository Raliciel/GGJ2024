using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LastMonke", menuName = "Card/Attack/LastMonke", order = 1)]
public class LastMonke : CardSO
{
    public int damage = 120;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses LastMonke.");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
