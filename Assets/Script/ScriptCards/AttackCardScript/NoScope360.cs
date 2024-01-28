using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NoScope360", menuName = "Card/Attack/NoScope360", order = 1)]
public class NoScope360 : CardSO
{
    public int angerCost = -15;
    public int damage = 50;
    public int receivedAnger = 25;
    public int reducedAnger = 25;
    public int[] chance = new int[2] {85, 15};
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
                DialogueSystem.Log($"Nice attempt of 360 No Scope by {actor.name}, but he missed.");
                actor.reducedAnger(reducedAnger);
                break;
            
            case 1:
                DialogueSystem.Log($"360 No Scope into {enemy.name}'s head by {actor.name}, what a spectacular.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);
                break;

        }

        return new int[1] {index};
    }
}
