using UnityEngine;
[CreateAssetMenu(fileName = "Uwoh", menuName = "Card/Special/Uwoh", order = 1)]
public class Uwoh: CardSO
{
    public int reducedAnger = 5;
    public int receivedAnger = 15;
    public int[] chance = new int[2] {60, 40};

    public override void DoAction(Unit actor, Unit enemy) {
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Fail
                Debug.Log($"{actor.name} want to calm {enemy.name} down with cute anime girl. He thinks he is a pedo instead, GL :D");
                Debug.Log($"{enemy.name} received {receivedAnger} anger.");
                enemy.receivedAnger(receivedAnger);
                break;

            case 1: //Success
                Debug.Log($"{actor.name} with power of god and anime on his side, he calm {enemy.name} down. Good Job!!");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.reducedAnger(reducedAnger);
                break;
        }
    } 
}