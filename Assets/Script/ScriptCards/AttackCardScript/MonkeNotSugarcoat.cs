using UnityEngine;

[CreateAssetMenu(fileName = "MonkeNotSugarcoat", menuName = "Card/Attack/MonkeNotSugarcoat", order = 1)]

public class MonkeNotSugarcoat: CardSO 
{
    public int angerCost = 20;
    public int damage = 10;
    public int receivedAnger = 4;
    public int[] chance = new int[2] {30, 70};

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) {
        timeSpent = 2;

        if(randomized != null && randomized.Length != 1) { return null; }

        int hit;

        actor.PayAngerCost(angerCost);

        if(randomized == null) {
            hit = 0;
            bool con = true;
            while(con) {
                int nexthit = Randomizer.random(chance);
                if(nexthit == 0) con = false;
                else hit++;
            }
        } else hit = randomized[0];
        timeSpent = 1 + (0.4f * hit);

        DialogueSystem.DisplayDialogue($"{actor.name} decides he is not gonna sugarcoat it.");
        Debug.Log($"{actor.name} damage {damage * hit} to {enemy.name}, receiving {receivedAnger * hit} anger.");

        for(int i = 0; i < hit; i++) {
            SetAudioSound.instance.DelayedPlaySFX(base.sfx, 0.4f * i);
            actor.ChangeSprite(this, PoseCatagory.use, 0.3f, 0.4f * i);
            enemy.ChangeSprite(this, PoseCatagory.react1, 0.3f, 0.4f * i);
            enemy.DelayedReduceHP(damage, 0.4f * i);
            enemy.DelayedRecoverAnger(receivedAnger, 0.4f * i);
        }

        actor.ChangeSprite(this, PoseCatagory.use, 0.3f, 0.4f * hit);
        enemy.ChangeSprite(this, PoseCatagory.react2, 0.3f, 0.4f * hit);
    
        return new int[1] {hit};
    }
}