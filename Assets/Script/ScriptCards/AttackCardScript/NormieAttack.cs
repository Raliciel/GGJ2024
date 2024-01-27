using UnityEngine;

[CreateAssetMenu(fileName = "NormieAttack", menuName = "Card/Attack/NormieAttack", order = 1)]
public class NormieAttack: CardSO 
{
    public int damage = 5;
    public int angerCost = 3;
    public int receivedAnger = 5;
    public int[] chance = new int[3] {10, 80, 10};

    public override void DoAction(Unit actor, Unit enemy) {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);
        
        switch(index) {
            case 0: //Miss
                Debug.Log($"{actor.name} try to attack {enemy.name} and misses.");
                break;

            case 1: //Normal
                Debug.Log($"{actor.name} attacks {enemy.name}.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);
                break;

            case 2: //Crit
                Debug.Log($"{actor.name} punches into {enemy.name} face heavily.");
                Debug.Log($"{actor.name} damage {damage * 2} hp to {enemy.name} receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage * 2);
                enemy.receivedAnger(receivedAnger);
                break;
        }
    }
}
