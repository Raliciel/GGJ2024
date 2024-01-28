using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBreaker", menuName = "Card/Attack/MonkeBreaker", order = 1)]
public class MonkeBreaker : CardSO
{
    public int damage = 15;
    public int angerCost = 7;
    public int receivedAnger = 5;
    public int reducedAnger = 15;
    public int[] chance = new int[2] {50, 50};
    SetAudioSound audio = SetAudioSound.instance;
    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) audio.PlaySFX(base.sfx);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.payAngerCost(angerCost);

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Miss
                DialogueSystem.Log($"{actor.name} uses MonkeBreaker into {enemy.name}, yet the punch is too soft to even felt.");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.reducedAnger(reducedAnger);
                break;

            case 1:
                DialogueSystem.Log($"{actor.name} uses MonkeBreaker into {enemy.name}.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);
                break;
        }

        return new int[1] {index};
    }
}
