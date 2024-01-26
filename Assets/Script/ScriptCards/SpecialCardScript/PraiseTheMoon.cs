using UnityEngine;

[CreateAssetMenu(fileName = "PraiseTheMoon", menuName = "Card/PraiseTheMoon", order = 1)]
public class PraiseTheMoon : CardSO 
{
    public int angerCost = 7;
    public int reducedAnger = 15;
    public int[] chance = new int[2] {50, 50};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);
    
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
    }
}