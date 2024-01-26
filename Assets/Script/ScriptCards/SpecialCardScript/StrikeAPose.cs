using UnityEngine;

[CreateAssetMenu(fileName = "StrikeAPose", menuName = "Card/StrikeAPose", order = 1)]
public class StrikeAPose : CardSO 
{
    public int hpCost = 7;
    public int reducedAnger = 15;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {25, 75};

    public override void DoAction(Unit actor, Unit enemy)
    {
        actor.payHPCost(hpCost);
        int index = Randomizer.random(chance);
    
        switch(index) {
            case 0: //Fail
                Debug.Log(actor.name + " strike the pose fabulously. However, " + enemy.name + " is not a fan of JoJo.");
                Debug.Log(enemy.name + " received " + receivedAnger + " anger.");
                enemy.receivedAnger(receivedAnger);
                break;

            case 1: //Normal
                Debug.Log(actor.name + " strike the pose fabulously.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.reducedAnger(reducedAnger);
                break;
        }
    }
}