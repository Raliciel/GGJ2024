using UnityEngine;

[CreateAssetMenu(fileName = "StrikeAPose", menuName = "Card/Special/StrikeAPose", order = 1)]
public class StrikeAPose : CardSO 
{
    public int hpCost = 7;
    public int reducedAnger = 15;
    public int receivedAnger = 5;
    public int[] chance = new int[2] {25, 75};

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null)
    {
        ChangeSprite(actor, PoseCatagory.use);

        if (randomized.Length != 1 && randomized != null) { return null; }

        int index;

        actor.payHPCost(hpCost);

        if (randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];
    
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

        return new int[1] { index };
    }
}