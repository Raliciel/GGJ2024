using UnityEngine;

[CreateAssetMenu(fileName = "NormieAttack", menuName = "Card/Attack/NormieAttack", order = 1)]
public class NormieAttack: CardSO 
{
    public int damage = 5;
    public int angerCost = 3;
    public int receivedAnger = 5;
    public int[] chance = new int[3] {10, 80, 10};
    SetAudioSound audio = SetAudioSound.instance;

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) 
    {
        timeSpent = 2;

        if (base.sfx != null) audio.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if(randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.payAngerCost(angerCost);

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];
        
        switch(index) {
            case 0: //Miss
                DialogueSystem.Log($"{actor.name} try to attack {enemy.name} and misses.");
                break;

            case 1: //Normal
                DialogueSystem.Log($"{actor.name} attacks {enemy.name}.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                break;

            case 2: //Crit
                DialogueSystem.Log($"{actor.name} punches into {enemy.name} face heavily.");
                Debug.Log($"{actor.name} damage {damage * 2} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage * 2);
                enemy.receivedAnger(receivedAnger);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                break;
        }

        return new int[1] {index};
    }
}
