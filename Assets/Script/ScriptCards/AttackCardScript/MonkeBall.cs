using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBall", menuName = "Card/Attack/MonkeBall", order = 1)]
public class MonkeBall : CardSO
{
    public int damage = 15;
    public int angerCost = 10;
    public int[] chance = new int[2] {50, 50};
    

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
                DialogueSystem.DisplayDialogue( $"{actor.name} uses MonkeBall, and the Monke doesn't come out.");
                break;

            case 1: //Normal
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"{enemy.name} had been forcefully taken in to the ball but it won't fit.");
                Debug.Log($"{actor.name} damage {damage} to {enemy.name}");
                enemy.ReduceHP(damage);
                break;

        }

        return new int[1] {index};
    }
}
