using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GetCancelled", menuName = "Card/GetCancelled", order = 1)]
public class GetCancelled : CardSO
{
    public int damage = 10;
    public int angerCost = 5;
    public int receivedAnger = 10;
    public int[] chance = new int[2] {50, 50};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: // Drama Backfire
                Debug.Log(actor.name + " uses GetCancelled. (Backfire)");
                Debug.Log(actor.name + " damage " + damage + " hp to " + actor.name);
                actor.receivedDamage(damage);
                Debug.Log(actor.name + " received " + receivedAnger + " anger.");
                actor.receivedAnger(receivedAnger);
                break;

            case 1: // Normal
                Debug.Log(actor.name + " uses GetCancelled. (Normal)");
                Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
                enemy.receivedDamage(damage);
                Debug.Log(enemy.name + " received " + receivedAnger + " anger.");
                enemy.receivedAnger(receivedAnger);
                break;
        }
    }
}
