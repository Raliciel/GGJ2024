using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GigaMonkeBreaker", menuName = "Card/Attack/GigaMonkeBreaker", order = 1)]
public class GigaMonkeBreaker : CardSO
{
    public int damage = 25;
    public int angerCost = 15;
    public int[] chance = new int[2] {70, 30};

    [Header("Miss Parameter")]
    public int recoil = 10;
    public int receivedAnger = 5;

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " use GigaMonkeBreaker. (Miss)");
                Debug.Log(actor.name + " damage " + recoil + " hp to " + actor.name);
                actor.receivedDamage(recoil);
                Debug.Log(actor.name + " received " + receivedAnger + " anger.");
                actor.receivedAnger(receivedAnger);
                break;
            case 1: //Normal
                Debug.Log(actor.name + " use GigaMonkeBreaker. (Normal)");
                Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
                enemy.receivedDamage(damage);
                break;

        }
    }
}
