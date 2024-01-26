using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NormalAttack", menuName = "Card/NormalAttack", order = 1)]
public class NormalAttack: CardSO 
{
    public int damage = 10;
    public int[] chance = new int[3] {10, 80, 10};

    public override void DoAction(Unit actor, Unit enemy) {
        int index = Randomizer.random(chance);
        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " uses NormalAttack. (Miss)");
                break;

            case 1: //Normal
                Debug.Log(actor.name + " uses NormalAttack. (Normal)");
                Debug.Log(actor.name + " damage " + damage +  " hp to " + enemy.name);
                enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - damage);
                break;

            case 2: //Crit
                Debug.Log(actor.name + " uses NormalAttack. (Crit)");
                Debug.Log(actor.name + " damage " + (damage * 2) +  " hp to " + enemy.name);
                enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - (damage * 2)); 
                break;
        }
    }
}
