using UnityEngine;
[CreateAssetMenu(fileName = "MonkeGambit", menuName = "Card/Attack/MonkeGambit", order = 1)]
public class MonkeGambit : CardSO
{
    public int damage = 10;
    public int[] chance = new int[3] {33, 34, 33};

    public override int[] DoAction(Unit actor, Unit enemy, int[] randomized = null) {
        if(randomized.Length != 1 && randomized != null) { return null; }

        int index;

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0: 
                Debug.Log($"{actor.name} shot a gambit into himself, unlucky, he got shotted.");
                actor.receivedDamage(damage);
                break;

            case 1:
                Debug.Log($"{actor.name} shot a gambit and no one got hit.");
                break;

            case 2:
                Debug.Log($"{actor.name} shot a gambit into {enemy.name} his knee, goddamn.");
                enemy.receivedDamage(damage);
                break;

        }

        return new int[1] {index};
    }
}