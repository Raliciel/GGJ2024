using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonkeBall", menuName = "Card/Attack/MonkeBall", order = 1)]
public class MonkeBall : CardSO
{
    public int damage = 15;
    public int angerCost = 10;
    public int[] chance = new int[2] {50, 50};
    SetAudioSound audio = SetAudioSound.instance;

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;
        
        if (base.sfx != null) audio.PlaySFX(base.sfx);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.payAngerCost(angerCost);

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Miss
                DialogueSystem.Log( $"{actor.name} uses MonkeBall, and the Monke doesn't come out.");
                break;

            case 1: //Normal
                DialogueSystem.Log($"{actor.name} uses MonkeBall. It came out with a bat and hit it into {enemy.name} face");
                Debug.Log($"{actor.name} damage {damage} to {enemy.name}");
                enemy.receivedDamage(damage);
                break;

        }

        return new int[1] {index};
    }
}
