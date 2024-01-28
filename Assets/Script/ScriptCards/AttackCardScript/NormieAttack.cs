using UnityEngine;

[CreateAssetMenu(fileName = "NormieAttack", menuName = "Card/Attack/NormieAttack", order = 1)]
public class NormieAttack: CardSO 
{
    public int damage = 5;
    public int angerCost = 3;
    public int receivedAnger = 5;
    public int[] chance = new int[3] {10, 80, 10};
    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) 
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if(randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];
        
        switch(index) {
            case 0: //Miss
                DialogueSystem.DisplayDialogue($"{actor.name} try to attack {enemy.name} and misses.");
                break;

            case 1: //Normal
                DialogueSystem.DisplayDialogue($"{actor.name} attacks {enemy.name}.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.ReduceHP(damage);
                enemy.RecoverAnger(receivedAnger);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                break;

            case 2: //Crit
                DialogueSystem.DisplayDialogue($"{actor.name} punches into {enemy.name} face heavily.");
                Debug.Log($"{actor.name} damage {damage * 2} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.ReduceHP(damage * 2);
                enemy.RecoverAnger(receivedAnger);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                break;
        }

        return new int[1] {index};
    }
}
