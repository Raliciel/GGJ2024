using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LifeCouldBeDream", menuName = "Card/Defend/LifeCouldBeDream", order = 1)]
public class LifeCouldBeDream : CardSO
{   
    public int angerCost = 15;
    SetAudioSound audio = SetAudioSound.instance;
    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) audio.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        enemy.ChangeSprite(this, PoseCatagory.react1);
        if (randomized != null) return null;

        actor.payAngerCost(angerCost);
        actor.setIsDefend(true);
        DialogueSystem.Log($"{actor.name} transform into a cube that can take you to a paradise up above.");

        return null;
    }
}