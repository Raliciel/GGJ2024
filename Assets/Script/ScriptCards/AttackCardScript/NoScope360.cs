using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NoScope360", menuName = "Card/Attack/NoScope360", order = 1)]
public class NoScope360 : CardSO
{
    public int angerCost = -15;
    public int damage = 50;
    public int receivedAnger = 25;
    public int reducedAnger = 25;
    public int[] chance = new int[2] {85, 15};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log($"Nice attempt of 360 No Scope by {actor.name}, but he missed.");
                actor.reducedAnger(reducedAnger);
            
            case 1:
                Debug.Log($"360 No Scope into {enemy.name}'s head by {actor.name}, what a spectacular.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);

        }
    }
}
