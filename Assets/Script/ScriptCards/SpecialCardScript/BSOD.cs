using UnityEngine;
[CreateAssetMenu(fileName = "BSOD", menuName = "Card/Special/BSOD", order = 1)]
public class BSOD: CardSO
{
    public int hpCost = 15;
    public int angerCost = 15;
    public int damage = 100;
    public int recoil = 15;
    public int receivedAnger = 15;
    public int[] chance = new int[2] {70, 30};
    

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
                DialogueSystem.DisplayDialogue($"Blue Screen of Death has been backfired to {actor.name}");
                Debug.Log($"{actor.name} damage {recoil} hp to {actor.name} and received {receivedAnger} anger");
                actor.ReduceHP(recoil);
                actor.RecoverAnger(receivedAnger);
                break;

            case 1: //Success
                actor.ChangeSprite(this, PoseCatagory.use);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"Blue Screen of Death has been casted upon {enemy.name}");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}");
                enemy.ReduceHP(damage);
                break;
        }

        return new int[1] { index };
    } 
}