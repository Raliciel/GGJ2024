using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GetCancelled", menuName = "Card/Attack/GetCancelled", order = 1)]
public class GetCancelled : CardSO
{
    public int damage = 10;
    public int angerCost = 5;
    public int receivedAnger = 10;
    public int[] chance = new int[2] {50, 50};

    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);
        
        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: // Drama Backfire
                actor.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue($"{actor.name} try to cancel {enemy.name}. However, the plan backfire and the social cancelled him instead.");
                Debug.Log($"{actor.name} damage {damage} to {actor.name} and received {receivedAnger} anger.");
                actor.ReduceHP(damage);
                actor.RecoverAnger(receivedAnger);
                break;

            case 1: // Normal
                actor.ChangeSprite(this, PoseCatagory.use);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"With the help of social networks, {actor.name} successfully cancel {enemy.name}.");
                Debug.Log($"{actor.name} damage {damage} to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.ReduceHP(damage);
                enemy.RecoverAnger(receivedAnger);
                break;
        }

        return new int[1] {index};
    }
}
