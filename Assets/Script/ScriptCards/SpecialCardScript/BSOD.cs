using UnityEngine;
[CreateAssetMenu(fileName = "BSOD", menuName = "Card/Special/BSOD", order = 1)]
public class BSOD: CardSO
{
    public int hpCost = 50;
    public int reducedAnger = 100;
    public int recoil = 50;
    public int[] chance = new int[2] {70, 30};

    public override void DoAction(Unit actor, Unit enemy) {
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Fail
                Debug.Log($"Blue Screen of Death has been backfired to {actor.name}");
                Debug.Log($"{actor.name} damage {recoil} hp to {actor.name}");
                actor.receivedDamage(recoil);
                break;

            case 1: //Success
                Debug.Log($"Blue Screen of Death has been casted upon {enemy.name}");
                Debug.Log($"{enemy.name} anger has reduced by {reducedAnger}.");
                enemy.reducedAnger(reducedAnger);
                break;
        }
    } 
}