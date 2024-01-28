using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GigaMonkeBreaker", menuName = "Card/Attack/GigaMonkeBreaker", order = 1)]
public class GigaMonkeBreaker : CardSO
{
    public int damage = 25;
    public int angerCost = 15;
    public int receivedAnger = 25;
    public int[] chance = new int[2] {70, 30};

    [Header("Miss Parameter")]
    public int recoil = 10;
    public int recoilAnger = 5;

    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        if(randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Miss
                enemy.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue($"{actor.name} uses GigaMonkeBreaker into {enemy.name}, however the drill exploded.");
                Debug.Log($"{actor.name} damage {recoil} hp to {actor.name}, also received {recoilAnger} anger.");
                actor.ReduceHP(recoil);
                actor.RecoverAnger(recoilAnger);
                break;

            case 1: //Normal
                actor.ChangeSprite(this, PoseCatagory.use);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"{actor.name} use GigaMonkeBreaker and drill {enemy.name} out of existence.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.ReduceHP(damage);
                enemy.RecoverAnger(receivedAnger);
                break;

        }

        return new int[1] {index};
    }
}
