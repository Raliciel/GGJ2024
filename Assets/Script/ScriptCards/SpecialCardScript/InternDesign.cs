using UnityEngine;
[CreateAssetMenu(fileName = "InternDesign", menuName = "Card/Special/InternDesign", order = 1)]

public class InternDesign: CardSO 
{
    SetAudioSound audio = SetAudioSound.instance;

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null)
    {
        if (base.sfx != null) audio.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if(randomized != null) return null;

        DialogueSystem.Log($"Upon interference of some interns, {actor.name} Hp and Anger are reseted");
        actor.SetCurrentAngerPoint(actor.angerPoint);
        actor.SetCurrentHealthPoint(actor.healthPoint);
    
        return null;
    }
}