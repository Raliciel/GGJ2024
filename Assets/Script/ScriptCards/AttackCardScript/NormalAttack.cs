using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalAttack", menuName = "Card/NormalAttack", order = 1)]
public class NormalAttack: CardSO 
{
    public int damage = 10;

    public override void DoAction(Unit actor, Unit enemy) {
        Debug.Log(actor.name + " uses NormalAttack.");
        Debug.Log(actor.name + " damage " + damage +  " hp to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
    }
}
