using UnityEngine;

[CreateAssetMenu(fileName = "GiveTheBanana", menuName = "Card/GiveTheBanana", order = 1)]
public class GiveTheBanana : CardSO 
{
    public int angerCost = -10;
    public int reducedAnger = 10;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {20, 80};

    public override void DoAction(Unit actor, Unit enemy) 
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch(index) {
            case 0: //Rotten banana
                Debug.Log(actor.name + " gives " + enemy.name + " a banana. Sadly, it's rotten.");
                Debug.Log(enemy.name + " received " + receivedAnger + " anger.");
                enemy.receivedAnger(receivedAnger);
                break;
            
            case 1: //Normal
                Debug.Log(actor.name + " gives " + enemy.name + " a banana.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.reducedAnger(reducedAnger);
                break;
        }
    }
}