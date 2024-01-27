using UnityEngine;

[CreateAssetMenu(fileName = "PraiseTheSun", menuName = "Card/Special/PraiseTheSun", order = 1)]
public class PraiseTheSun : CardSO 
{
    public int angerCost = 10;
    public int reducedAnger = 15;
    public int[] chance = new int[2] {30, 70};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);
    
        switch(index) {
            case 0: //Miss
                Debug.Log(actor.name + " praise the sun and failed.");
                break;

            case 1:
                Debug.Log(actor.name + " praise the sun. " + enemy.name + " become calmer.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.reducedAnger(reducedAnger);
                break;
        }
    }
}