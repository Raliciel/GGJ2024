using UnityEngine;

[CreateAssetMenu(fileName = "StrikeAPose", menuName = "Card/Special/StrikeAPose", order = 1)]
public class StrikeAPose : CardSO 
{
    public int hpCost = 7;
    public int reducedAnger = 15;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {25, 75};
    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null)
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);

        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayHPCost(hpCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];
    
        switch(index) {
            case 0: //Fail
                enemy.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue(actor.name + " strike the pose fabulously. However, " + enemy.name + " is not a fan of JoJo.");
                Debug.Log(enemy.name + " received " + receivedAnger + " anger.");
                enemy.RecoverAnger(receivedAnger);
                break;

            case 1: //Normal
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue(actor.name + " strike the pose fabulously.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.ReduceAnger(reducedAnger);
                break;
        }

        return new int[1] { index };
    }
}