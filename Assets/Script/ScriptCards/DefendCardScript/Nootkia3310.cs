using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nootkia3310", menuName = "Card/Defend/Nootkia3310", order = 1)]
public class Nootkia3310 : CardSO
{
    public int hpCost = 10;
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

        actor.payHPCost(hpCost);
        
        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0:
                DialogueSystem.Log($"{actor.name} try to contact Nootkia3310, got shocked instead.");
                break;
            case 1:
                DialogueSystem.Log($"{actor.name} obtains Nootkia3310, the material is so hard.");
                actor.setIsDefend(true);
                actor.receivedAnger(receivedAnger);
                break;
        }

        return new int[1] { index };
    }
}