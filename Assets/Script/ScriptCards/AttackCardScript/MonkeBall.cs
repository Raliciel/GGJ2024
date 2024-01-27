using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBall", menuName = "Card/Attack/MonkeBall", order = 1)]
public class MonkeBall : CardSO
{
    public int damage = 15;
    public int angerCost = 10;
    public int[] chance = new int[2] {50, 50};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " uses MonkeBall. (Miss)");
                break;

            case 1: //Normal
                Debug.Log(actor.name + " uses MonkeBall. (Normal)");
                Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
                enemy.receivedDamage(damage);
                break;

        }
    }
}
