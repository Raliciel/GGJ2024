using UnityEngine;

[CreateAssetMenu(fileName = "vwti", menuName = "Card/vwti", order = 1)]

public class vwti : CardSO 
{
    public int angerCost = 10;
    public int reducedAnger = 10;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {10, 90};

    public override void DoAction(Unit actor, Unit enemy) 
    {
        actor.payAngerCost(angerCost);
        int index = Randomizer.random(chance);

        switch (index) {
            case 0: //Faile
                Debug.Log(actor.name + " try shitposting " + enemy.name + ". He's not enjoyed at all.");
                Debug.Log(enemy.name + " received " + receivedAnger + " anger.");
                enemy.receivedAnger(receivedAnger);
                break;
            
            case 1: //Normal
                Debug.Log(actor.name + "  try shitposting " + enemy.name + ". It's a success.");
                Debug.Log(enemy.name + " anger has reduced by " + reducedAnger);
                enemy.reducedAnger(reducedAnger);
                break;
        }
    }
}