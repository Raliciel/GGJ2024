using UnityEngine;
[CreateAssetMenu(fileName = "BSOD", menuName = "Card/Special/BSOD", order = 1)]
public class BSOD: CardSO
{
    public int hpCost = 15;
    public int angerCost = 15;
    public int damage = 100;
    public int recoil = 15;
    public int receivedAnger = 15;
    public int[] chance = new int[2] {70, 30};

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null) 
    {
        if (randomized.Length != 1 && randomized != null) { return null; }

        int index;

        actor.payAngerCost(angerCost);
        actor.payHPCost(hpCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Fail
                Debug.Log($"Blue Screen of Death has been backfired to {actor.name}");
                Debug.Log($"{actor.name} damage {recoil} hp to {actor.name} and received {receivedAnger} anger");
                actor.receivedDamage(recoil);
                actor.receivedAnger(receivedAnger);
                break;

            case 1: //Success
                Debug.Log($"Blue Screen of Death has been casted upon {enemy.name}");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}");
                enemy.receivedDamage(damage);
                break;
        }

        return new int[1] { index };
    } 
}