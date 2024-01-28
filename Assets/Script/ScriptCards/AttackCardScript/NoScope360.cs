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
    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Miss
                enemy.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue($"Nice attempt of 360 No Scope by {actor.name}, but he missed.");
                actor.ReduceAnger(reducedAnger);
                break;
            
            case 1:
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"360 No Scope into {enemy.name}'s head by {actor.name}, what a spectacular.");
                enemy.ReduceHP(damage);
                enemy.RecoverAnger(receivedAnger);
                break;

        }

        return new int[1] {index};
    }
}
