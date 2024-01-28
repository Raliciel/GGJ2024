using UnityEngine;

[CreateAssetMenu(fileName = "vwti", menuName = "Card/Special/vwti", order = 1)]

public class vwti : CardSO 
{
    public int angerCost = 10;
    public int reducedAnger = 10;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {10, 90};
    

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

        switch (index) {
            case 0: //Faile
                enemy.ChangeSprite(this, PoseCatagory.use);
                DialogueSystem.DisplayDialogue(actor.name + " try shitposting " + enemy.name + ". He's not enjoyed at all.");
                Debug.Log(enemy.name + " received " + receivedAnger + " anger.");
                enemy.RecoverAnger(receivedAnger);
                break;
            
            case 1: //Normal
                DialogueSystem.DisplayDialogue(actor.name + "  try shitposting " + enemy.name + ". It's a success.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.ReduceAnger(reducedAnger);
                break;
        }

        return new int[1] { index };
    }
}