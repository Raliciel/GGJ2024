using UnityEngine;

[CreateAssetMenu(fileName = "NormalAttack", menuName = "Card/NormalAttack", order = 1)]
public class NormalAttack: CardSO 
{
    public int damage = 5;
    public int angerCost = 3;
    public int[] chance = new int[3] {10, 80, 10};

    public override void DoAction(Unit actor, Unit enemy) {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);
        
        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " uses NormalAttack. (Miss)");
                break;

            case 1: //Normal
                Debug.Log(actor.name + " uses NormalAttack. (Normal)");
                Debug.Log(actor.name + " damage " + damage +  " hp to " + enemy.name);
                enemy.receivedDamage(damage);
                break;

            case 2: //Crit
                Debug.Log(actor.name + " uses NormalAttack. (Crit)");
                Debug.Log(actor.name + " damage " + (damage * 2) +  " hp to " + enemy.name);
                enemy.receivedDamage(damage * 2);
                break;
        }
    }
}
