using UnityEngine;
[CreateAssetMenu(fileName = "Uwoh", menuName = "Card/Special/Uwoh", order = 1)]
public class Uwoh: CardSO
{
    public int reducedAnger = 5;
    public int receivedAnger = 15;
    public int[] chance = new int[2] {60, 40};
    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) 
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Fail
                enemy.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue($"{actor.name} want to calm {enemy.name} down with cute anime girl. He thinks he is a pedo instead, GL :D");
                Debug.Log($"{enemy.name} received {receivedAnger} anger.");
                enemy.RecoverAnger(receivedAnger);
                break;

            case 1: //Success
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"{actor.name} with power of god and anime on his side, he calm {enemy.name} down. Good Job!!");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.ReduceAnger(reducedAnger);
                break;
        }

        return new int[1] { index };
    } 
}