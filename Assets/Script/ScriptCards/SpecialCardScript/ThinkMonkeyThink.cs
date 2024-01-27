using UnityEngine;
[CreateAssetMenu(fileName = "ThinkMonkeyThink", menuName = "Card/Special/ThinkMonkeyThink", order = 1)]

public class ThinkMonkeyThink: CardSO
{
    public int angerCost = 5;
    public int reducedAnger = 20;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {65, 35};

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null) 
    {
        actor.ChangeSprite(this, PoseCatagory.use);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;
        
        actor.payAngerCost(angerCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Fail
                enemy.ChangeSprite(this, PoseCatagory.react2);
                Debug.Log($"{actor.name} is gaslighting {enemy.name}. He failed miserably.");
                Debug.Log($"{enemy.name} received {receivedAnger} anger.");
                enemy.receivedAnger(receivedAnger);
                break;

            case 1: //Success
                enemy.ChangeSprite(this, PoseCatagory.react1);
                Debug.Log($"{actor.name} is gaslighting {enemy.name}, and he confused so hard he blushed.");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.reducedAnger(reducedAnger);
                break;
        }

        return new int[1] { index };
    }
}