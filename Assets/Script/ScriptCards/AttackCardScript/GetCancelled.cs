using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GetCancelled", menuName = "Card/Attack/GetCancelled", order = 1)]
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
                Debug.Log($"{actor.name} try to cancel {enemy.name}. However, the plan backfire and the social cancelled him instead.");
                Debug.Log($"{actor.name} damage {damage} to {actor.name} and received {receivedAnger} anger.");
                actor.receivedDamage(damage);
                actor.receivedAnger(receivedAnger);
                break;

            case 1: // Normal
                Debug.Log($"With the help of social networks, {actor.name} successfully cancel {enemy.name}.");
                Debug.Log($"{actor.name} damage {damage} to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);
                break;
        }
    }
}
