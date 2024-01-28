using UnityEngine;

[CreateAssetMenu(fileName = "MonkeNotSugarcoat", menuName = "Card/Attack/MonkeNotSugarcoat", order = 1)]

public class MonkeNotSugarcoat: CardSO 
{
    public int angerCost = 20;
    public int damage = 10;
    public int receivedAnger = 4;
    public int[] chance = new int[2] {25, 75};

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) {
        timeSpent = 2;

        if(randomized != null && randomized.Length != 1) { return null; }

        int hit;

        actor.payAngerCost(angerCost);

        if(randomized == null) {
            hit = 0;
            bool con = true;
            while(con) {
                int nexthit = Randomizer.random(chance);
                if(nexthit == 0) con = false;
                else hit++;
            }
        } else hit = randomized[0];

        DialogueSystem.Log($"{actor.name} decides he is not gonna sugarcoat it.");
        Debug.Log($"{actor.name} damage {damage * hit} to {enemy.name}, receiving {receivedAnger * hit} anger.");
        enemy.receivedDamage(damage * hit);
        enemy.receivedAnger(receivedAnger * hit);
    
        return new int[1] {hit};
    }
}