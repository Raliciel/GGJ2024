using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodySlam", menuName = "Card/BodySlam", order = 1)]
public class BodySlam : CardSO
{
    public int damage = 30;
    public int recoil = 5;

    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses BodySlam");
        Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
        Debug.Log(actor.name + " damage " + recoil + " hp to " + actor.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
        actor.SetCurrentHealthPoint(actor.GetCurrentHealthPoint() - recoil);
    }
}
