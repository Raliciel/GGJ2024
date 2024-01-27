using UnityEngine;

[CreateAssetMenu(fileName = "SplitAttack", menuName = "Card/Attack/SplitAttack", order = 1)]
public class SplitAttack : CardSO
{
    public int damage = 5;
    public int angerCost = 7;
    public int[] chance = new int[3] {15, 60, 25};
    public int[] addHit = new int[3] {60, 30, 10};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " uses SplitAttack. (Miss)");
                break;

            case 1: //Normal
                Debug.Log(actor.name + " uses SplitAttack. (Normal)");
                Debug.Log(actor.name + " damage " + damage * 2 + " hp to " + enemy.name);
                enemy.receivedDamage(damage * 2);
                break;
            
            case 2: //Chain Hit
                Debug.Log(actor.name + " uses SplitAttack. (Normal)");
                int hit = 3 + Randomizer.random(addHit);
                Debug.Log(actor.name + " damage " + damage * hit + " hp to " + enemy.name);
                enemy.receivedDamage(damage * hit);
                break;
        }
    }
}
