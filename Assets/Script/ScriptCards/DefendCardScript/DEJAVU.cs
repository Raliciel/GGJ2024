using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DEJAVU", menuName = "Card/Defend/DEJAVU", order = 1)]
public class DEJAVU : CardSO
{
    public int angerCost = 5;
    public int hpCost = 5;
    public int recoil = 5;
    public int reducedAnger = 15;
    public int[] chance = new int[3] { 35, 50, 15 };
    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        actor.payHPCost(hpCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Fail
                Debug.Log($"Despite feeling DEJA VU, {actor.name} drive too fast and crash into the fence.");
                actor.receivedDamage(recoil);
                break;
            case 1: //Deja Vu
                Debug.Log($"While feeling DEJA VU, {actor.name} drive too fast for {enemy.name} to catch.");
                actor.setIsDefend(true);
                break;
            case 2: //Kanzen DORIFUTO
                Debug.Log($"Kanzen DORIFUTO! With perfect drive, {actor.name} conquers the road and leaves everyone in awe.");
                actor.setIsDefend(true);
                enemy.reducedAnger(reducedAnger);
                break;
        }
    }
}