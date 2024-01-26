using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalAttack", menuName = "Card/NormalAttack", order = 1)]
public class NormalAttack: CardSO {
    public int hpModifier = -10;
    public int angerModifier = 3;

    public override void DoAction(Unit actor, Unit enemy) {
        Debug.Log(actor.name + " modify " + hpModifier+  " hp to " + enemy.name);
        Debug.Log(actor.name + " modify " + angerModifier + " anger to " + enemy.name);
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() + hpModifier);
        enemy.SetCurrentAngerPoint(enemy.GetCurrentAngerPoint() + angerModifier);
    }
}
