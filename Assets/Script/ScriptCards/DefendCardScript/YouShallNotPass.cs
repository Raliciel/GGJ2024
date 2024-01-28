using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "YouShallNotPass", menuName = "Card/Defend/YouShallNotPass", order = 1)]
public class YouShallNotPass : CardSO
{
    public int angerCost = -15;
    public int receivedAnger = 5;
    public int[] chance = new int[2] { 30, 70 };
    SetAudioSound audio = SetAudioSound.instance;
    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) audio.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0:
                actor.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"{actor.name} try to summon Gandalf for help, and {enemy.name} not allow it.");
                enemy.RecoverAnger(receivedAnger);
                break;

            case 1:
                DialogueSystem.DisplayDialogue($"With the power of Gandalf in {actor.name}'s hand, {enemy.name} shall not pass.");
                actor.SetDefendState(true);
                break;
        }

        return new int[1] { index };
    }
}