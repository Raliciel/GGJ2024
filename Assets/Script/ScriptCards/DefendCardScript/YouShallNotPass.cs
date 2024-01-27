using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "YouShallNotPass", menuName = "Card/Defend/YouShallNotPass", order = 1)]
public class YouShallNotPass : CardSO
{
    public int angerCost = -15;
    public int receivedAnger = 5;
    public int[] chance = new int[2] { 30, 70 };
    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null)
    {
        if (randomized.Length != 1 && randomized != null) { return null; }

        int index;

        actor.payAngerCost(angerCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: 
                Debug.Log($"{actor.name} try to summon Gandalf for help, and {enemy.name} not allow it.");
                enemy.receivedAnger(receivedAnger);
                break;

            case 1:
                Debug.Log($"With the power of Gandalf in {actor.name}'s hand, {enemy.name} shall not pass.");
                actor.setIsDefend(true);
                break;
        }
    }
}