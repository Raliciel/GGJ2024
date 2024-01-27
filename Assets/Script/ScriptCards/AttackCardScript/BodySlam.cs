using UnityEngine;

[CreateAssetMenu(fileName = "BodySlam", menuName = "Card/Attack/BodySlam", order = 1)]
public class BodySlam : CardSO
{
    public int damage = 20;
    public int recoil = 5;
    public int receivedAnger = 5;
    public int angerCost = 10;
    public int[] chance = new int[2]{30, 70};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);
        
        switch(index) {
            case 0: //Miss
                Debug.Log($"{actor.name} body slams the ground so hard.");
                Debug.Log($"{actor.name} damage {recoil * 2} hp to {actor.name}");
                actor.receivedDamage(recoil * 2);
                break;
            
            case 1:
                Debug.Log($"{actor.name} body slams into {enemy.name} so hard they roll altogether.");
                
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);

                Debug.Log($"{actor.name} damage {recoil} hp to {actor.name}");
                actor.receivedDamage(recoil);
                break;
        }
    }
}
