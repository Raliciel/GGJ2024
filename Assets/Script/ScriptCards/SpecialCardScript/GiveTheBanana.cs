using UnityEngine;

[CreateAssetMenu(fileName = "GiveTheBanana", menuName = "Card/Special/GiveTheBanana", order = 1)]
public class GiveTheBanana : CardSO 
{
    public int angerCost = -10;
    public int reducedAnger = 10;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {20, 80};
    
    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) 
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);
        actor.ChangeSprite(this, PoseCatagory.use);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.PayAngerCost(angerCost);
        
        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: //Rotten banana
                enemy.ChangeSprite(this, PoseCatagory.react2);
                DialogueSystem.DisplayDialogue(actor.name + " gives " + enemy.name + " a banana. Sadly, it's rotten.");
                Debug.Log(enemy.name + " received " + receivedAnger + " anger.");
                enemy.RecoverAnger(receivedAnger);
                break;
            
            case 1: //Normal
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue(actor.name + " gives " + enemy.name + " a banana.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.ReduceAnger(reducedAnger);
                break;
        }
    
        return new int[1] { index };
    }
}