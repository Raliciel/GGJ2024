using UnityEngine;

[CreateAssetMenu(fileName = "PraiseTheMoon", menuName = "Card/Special/PraiseTheMoon", order = 1)]
public class PraiseTheMoon : CardSO 
{
    public int angerCost = 7;
    public int reducedAnger = 15;
    public int[] chance = new int[2] {50, 50};

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null)
    {
        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        actor.payAngerCost(angerCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];
    
        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " praise the moon and failed.");
                break;

            case 1:
                Debug.Log(actor.name + " praise the moon. " + enemy.name + " become calmer.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.reducedAnger(reducedAnger);
                break;
        }

        return new int[1] { index };
    }
}