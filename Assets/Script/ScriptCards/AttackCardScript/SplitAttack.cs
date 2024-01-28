using UnityEngine;

[CreateAssetMenu(fileName = "SplitAttack", menuName = "Card/Attack/SplitAttack", order = 1)]
public class SplitAttack : CardSO
{
    public int damage = 5;
    public int receivedAnger = 3;
    public int angerCost = 7;
    public int[] chance = new int[3] {15, 60, 25};
    public int[] addHit = new int[3] {60, 30, 10};

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if(randomized != null && randomized.Length != 2) { return null; }
        
        int index;
        int hit;

        actor.payAngerCost(angerCost);
        if(randomized == null) {
            index = Randomizer.random(chance);
            hit = 3 + Randomizer.random(addHit);
        } else { 
            index = randomized[0];
            hit = randomized[1];
        }

        switch(index) {
            case 0: //Miss
                DialogueSystem.Log($"{actor.name} try to hit {enemy.name}, hit the ground instead.");
                break;

            case 1: //Normal
                DialogueSystem.Log($"{actor.name} hit {enemy.name} 2 times in a row, unbelievable.");
                Debug.Log($"{actor.name} damage {damage * 2} hp to {enemy.name}, receiving {receivedAnger * 2} anger.");
                enemy.receivedDamage(damage * 2);
                enemy.receivedAnger(receivedAnger * 2);

                timeSpent = 4;
                break;
            
            case 2: //Chain Hit
                DialogueSystem.Log($"{actor.name} hit {enemy.name} 2 times in a row, but it not 2 times anymore.");
                Debug.Log($"{actor.name} damage {damage * hit} hp to {enemy.name}, receiving {receivedAnger * hit} anger.");
                enemy.receivedDamage(damage * hit);
                enemy.receivedAnger(receivedAnger * hit);

                timeSpent = 5;
                break;
        }

        return new int[2] {index, hit};
    }
}
