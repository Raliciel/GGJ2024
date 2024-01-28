using UnityEngine;

[CreateAssetMenu(fileName = "BodySlam", menuName = "Card/Attack/BodySlam", order = 1)]
public class BodySlam : CardSO
{
    public int damage = 20;
    public int recoil = 5;
    public int receivedAnger = 5;
    public int angerCost = 10;
    public int[] chance = new int[2]{30, 70};

    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;
        
        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch (index) {
            case 0: //Miss
                actor.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue($"{actor.name} body slams the ground so hard.");
                Debug.Log($"{actor.name} damage {recoil * 2} hp to {actor.name}");
                actor.ReduceHP(recoil * 2);
                break;
            
            case 1:
                actor.ChangeSprite(this, PoseCatagory.use);
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"{actor.name} body slams into {enemy.name} so hard they roll altogether.");
                Debug.Log($"{actor.name} damage {damage} hp to {enemy.name}, receiving {receivedAnger} anger.");
                enemy.ReduceHP(damage);
                enemy.RecoverAnger(receivedAnger);

                Debug.Log($"{actor.name} damage {recoil} hp to {actor.name}");
                actor.ReduceHP(recoil);
                break;
        }

        return new int[1] { index };
    }
}
