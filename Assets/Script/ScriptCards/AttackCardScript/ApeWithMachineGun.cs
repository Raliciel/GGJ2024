using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ApeWithMachineGun", menuName = "Card/Attack/ApeWithMachineGun", order = 1)]
public class ApeWithMachineGun : CardSO
{
    public int damage = 3;
    public int totalHit = 10;
    public int angerCost = 8;

    public float receivedAnger = 1.3f;
    public int[] chance = new int[2]{10, 90};

    public int recoil = 5;

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Miss
                Debug.Log($"{actor.name} use machine gun, but recoil of the gun is so hard it bounce back and hit his face.");
                Debug.Log($"{actor.name} damage {recoil} to {actor.name}.");
                actor.receivedDamage(recoil);
                break;
            
            case 1: //Normal
                int hit = 0;
                for(int i = 0; i < totalHit; i++) {
                    if(UnityEngine.Random.Range(0, 1) >= 0.5) hit++;
                }

                Debug.Log($"{actor.name} use machine gun and hit {hit} out of {totalHit} shot.");
                Debug.Log($"{actor.name} damage {damage * hit} to {enemy.name}, receiving {(int)Mathf.Ceil(receivedAnger * hit)} anger.");
                enemy.receivedDamage(damage * hit);
                enemy.receivedAnger((int)Mathf.Ceil(receivedAnger * hit));
                break;
        }
    }
}
