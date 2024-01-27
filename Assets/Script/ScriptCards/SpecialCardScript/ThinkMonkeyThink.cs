using UnityEngine;
[CreateAssetMenu(fileName = "ThinkMonkeyThink", menuName = "Card/ThinkMonkeyThink", order = 1)]

public class ThinkMonkeyThink: CardSO
{
    public int angerCost = 5;
    public int reducedAnger = 20;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {65, 35};

    public override void DoAction(Unit actor, Unit enemy) {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Fail
                Debug.Log($"{actor.name} is gaslighting {enemy.name}. He failed miserably.");
                Debug.Log($"{enemy.name} received {receivedAnger} anger.");
                enemy.receivedAnger(receivedAnger);
                break;

            case 1: //Success
                Debug.Log($"{actor.name} is gaslighting {enemy.name}, and he confused so hard he blushed.");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.reducedAnger(reducedAnger);
                break;
        }
    }
}