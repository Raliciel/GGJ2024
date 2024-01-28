using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DEJAVU", menuName = "Card/Defend/DEJAVU", order = 1)]
public class DEJAVU : CardSO
{
    public int angerCost = 5;
    public int hpCost = 5;
    public int recoil = 5;
    public int reducedAnger = 15;
    public int[] chance = new int[3] { 35, 50, 15 };
    
    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);
        actor.PayHPCost(hpCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Fail
                actor.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue($"Despite feeling DEJA VU, {actor.name} drive too fast and crash into the fence.");
                actor.ReduceHP(recoil);
                break;
            case 1: //Deja Vu
                actor.ChangeSprite(this, PoseCatagory.use);
                DialogueSystem.DisplayDialogue($"While feeling DEJA VU, {actor.name} drive too fast for {enemy.name} to catch.");
                actor.SetDefendState(true);
                break;
            case 2: //Kanzen DORIFUTO
                actor.ChangeSprite(this, PoseCatagory.use);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"Kanzen DORIFUTO! With perfect drive, {actor.name} conquers the road and leaves everyone in awe.");
                actor.SetDefendState(true);
                enemy.ReduceAnger(reducedAnger);
                break;
        }

        return new int[1] {index};
    }
}