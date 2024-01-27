using UnityEngine;

[CreateAssetMenu(fileName = "PraiseTheSun", menuName = "Card/Special/PraiseTheSun", order = 1)]
public class PraiseTheSun : CardSO 
{
    public int angerCost = 10;
    public int reducedAnger = 15;
    public int[] chance = new int[2] {30, 70};

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null)
    {
        actor.ChangeSprite(this, PoseCatagory.use);
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;
        
        actor.payAngerCost(angerCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];
    
        switch(index) {
            case 0: //Miss

                DialogueSystem.Log(actor.name + " praise the sun and failed.");
                break;

            case 1:
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.Log(actor.name + " praise the sun. " + enemy.name + " become calmer.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.reducedAnger(reducedAnger);
                break;
        }

        return new int[1] { index };
    }
}