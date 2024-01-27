using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBreaker", menuName = "Card/Attack/MonkeBreaker", order = 1)]
public class MonkeBreaker : CardSO
{
    public int damage = 15;
    public int angerCost = 7;
    public int[] chance = new int[2] {50, 50};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " uses MonkeBreaker. (Failed)");
                break;

            case 1:
                Debug.Log(actor.name + " uses MonkeBreaker. (Normal)");
                Debug.Log(actor.name + " damage " + damage +  " hp to " + enemy.name);
                enemy.receivedDamage(damage);
                break;
        }
    }
}
