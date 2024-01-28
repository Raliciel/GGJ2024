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
    SetAudioSound audio = SetAudioSound.instance;

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) 
    {
        timeSpent = 2;

        if (base.sfx != null) audio.PlaySFX(base.sfx);
        ChangeSprite(actor, PoseCatagory.use);

        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);
        
        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Fail
                DialogueSystem.DisplayDialogue($"{actor.name} orders food to eat, but seem he has to eat alone.");
                Debug.Log($"{enemy.name} received {receivedAnger} anger.");
                enemy.RecoverAnger(receivedAnger);
                Debug.Log($"{actor.name} has recovered {failedHpRecover} HP.");
                actor.RecoverHP(failedHpRecover);
                break;

            case 1: //Success
                DialogueSystem.DisplayDialogue($"{actor.name} orders food to eat with {enemy.name}, both seem enjoyed.");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.ReduceAnger(reducedAnger);
                Debug.Log($"Both units recover {successHpRecover} HP.");
                actor.RecoverHP(successHpRecover);
                enemy.RecoverHP(successHpRecover);
                break;
        }

        return new int[1] { index };
    }
}