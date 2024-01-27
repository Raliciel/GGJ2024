using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBreaker", menuName = "Card/Attack/MonkeBreaker", order = 1)]
public class MonkeBreaker : CardSO
{
    public int damage = 15;
    public int angerCost = 7;
    public int receivedAnger = 5;
    public int reducedAnger = 15;
    public int[] chance = new int[2] {50, 50};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log($"{actor.name} uses MonkeBreaker into {enemy.name}, yet the punch is too soft to even felt.");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.reducedAnger(reducedAnger);
                break;

            case 1:
                Debug.Log($"{actor.name} uses MonkeBreaker into {enemy.name}.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);
                break;
        }
    }
}
