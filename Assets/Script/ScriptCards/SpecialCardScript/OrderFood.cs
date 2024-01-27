using UnityEngine;
[CreateAssetMenu(fileName = "OrderFood", menuName = "Card/Special/OrderFood", order = 1)]
public class OrderFood : CardSO
{
    public int angerCost = 10;
    public int reducedAnger = 10;
    public int successHpRecover = 20;
    public int receivedAnger = 5;
    public int failedHpRecover = 15;
    public int[] chance = new int[2] {20, 80}; 

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null) {
        ChangeSprite(actor, PoseCatagory.use);

        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.payAngerCost(angerCost);
        
        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Fail
                DialogueSystem.Log($"{actor.name} orders food to eat, but seem he has to eat alone.");
                Debug.Log($"{enemy.name} received {receivedAnger} anger.");
                enemy.receivedAnger(receivedAnger);
                Debug.Log($"{actor.name} has recovered {failedHpRecover} HP.");
                actor.hpRecover(failedHpRecover);
                break;

            case 1: //Success
                DialogueSystem.Log($"{actor.name} orders food to eat with {enemy.name}, both seem enjoyed.");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.reducedAnger(reducedAnger);
                Debug.Log($"Both units recover {successHpRecover} HP.");
                actor.hpRecover(successHpRecover);
                enemy.hpRecover(successHpRecover);
                break;
        }

        return new int[1] { index };
    }
}