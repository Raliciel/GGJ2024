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

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;
        
        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if(randomized != null && randomized.Length != 2) { return null; }

        int index;
        int hit;

        actor.PayAngerCost(angerCost);

        if(randomized == null) {
            index = Randomizer.random(chance);
            
            hit = 0;
            for(int i = 0; i < totalHit; i++) {
                if(UnityEngine.Random.Range(0f, 1f) >= 0.5) hit++;
            }

        } else { 
            index = randomized[0];
            hit = randomized[1];
        }

        switch(index) {
            case 0: //Miss
                enemy.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue($"{actor.name} use machine gun, but recoil of the gun is so hard it bounce back and hit his face.");
                Debug.Log($"{actor.name} damage {recoil} to {actor.name}.");
                actor.ReduceHP(recoil);
                break;
            
            case 1: //Normal
                DialogueSystem.DisplayDialogue($"{actor.name} use machine gun and hit {hit} out of {totalHit} shot.");
                Debug.Log($"{actor.name} damage {damage * hit} to {enemy.name}, receiving {(int)Mathf.Ceil(receivedAnger * hit)} anger.");

                for(int i = 0; i < hit; i++) {
                    enemy.ChangeSprite(this, PoseCatagory.react1, 0.1f, 0.2f * i);
                    enemy.DelayedReduceHP(damage, 0.2f * i);
                }
                enemy.RecoverAnger((int)Mathf.Ceil(receivedAnger));

                timeSpent = 3f;
                break;
        }

        return new int[2] {index, hit};
    }
}
