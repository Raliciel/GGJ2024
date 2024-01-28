using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GigaMonkeBreaker", menuName = "Card/Attack/GigaMonkeBreaker", order = 1)]
public class GigaMonkeBreaker : CardSO
{
    public int damage = 25;
    public int angerCost = 15;
    public int receivedAnger = 25;
    public int[] chance = new int[2] {70, 30};

    [Header("Miss Parameter")]
    public int recoil = 10;
    public int recoilAnger = 5;

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;
        
        actor.ChangeSprite(this, PoseCatagory.use);
        if(randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.payAngerCost(angerCost);

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Miss
                enemy.ChangeSprite(this, PoseCatagory.react2);
                Debug.Log($"{actor.name} uses GigaMonkeBreaker into {enemy.name}, however the drill exploded.");
                Debug.Log($"{actor.name} damage {recoil} hp to {actor.name}, also received {recoilAnger} anger.");
                actor.receivedDamage(recoil);
                actor.receivedAnger(recoilAnger);
                break;

            case 1: //Normal
                enemy.ChangeSprite(this, PoseCatagory.react1);
                Debug.Log($"{actor.name} use GigaMonkeBreaker and drill {enemy.name} out of existence.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.receivedDamage(damage);
                enemy.receivedAnger(receivedAnger);
                break;

        }

        return new int[1] {index};
    }
}
