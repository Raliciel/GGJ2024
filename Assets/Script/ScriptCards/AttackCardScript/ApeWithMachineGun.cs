using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ApeWithMachineGun", menuName = "Card/Attack/ApeWithMachineGun", order = 1)]
public class ApeWithMachineGun : CardSO
{
    public int damage = 3;
    public int totalHit = 10;
    public int angerCost = 8;
    public int[] chance = new int[2]{10, 90};

    public int recoil = 5;

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " uses ApeWithMachineGun. (Recoil)");
                Debug.Log(actor.name + " damage " + recoil + " hp to " + actor.name);
                actor.receivedDamage(recoil);
                break;
            
            case 1: //Normal
                int hit = 0;
                for(int i = 0; i < totalHit; i++) {
                    if(UnityEngine.Random.Range(0, 1) >= 0.5) hit++;
                }

                Debug.Log(actor.name + " uses ApeWithMachineGun. (" + hit + "/" + totalHit +")");
                Debug.Log(actor.name + " damage " + (damage * hit) +  " hp to " + enemy.name);
                enemy.receivedDamage(damage * hit);
                break;
        }
    }
}
