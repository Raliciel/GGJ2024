using UnityEngine;

[CreateAssetMenu(fileName = "BodySlam", menuName = "Card/BodySlam", order = 1)]
public class BodySlam : CardSO
{
    public int damage = 20;
    public int recoil = 5;
    public int angerCost = 10;
    public int[] chance = new int[2]{30, 70};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);
        
        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " uses BodySlam. (Miss)");
                Debug.Log(actor.name + " damage " + recoil + " hp to " + actor.name);
                actor.receivedDamage(recoil);
                break;
            
            case 1:
                Debug.Log(actor.name + " uses BodySlam. (Normal)");
                Debug.Log(actor.name + " damage " + damage + " hp to " + enemy.name);
                Debug.Log(actor.name + " damage " + recoil + " hp to " + actor.name);
                enemy.receivedDamage(damage);
                actor.receivedDamage(recoil);
                break;
        }
    }
}
