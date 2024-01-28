using UnityEngine;
[CreateAssetMenu(fileName = "MonkeGambit", menuName = "Card/Attack/MonkeGambit", order = 1)]
public class MonkeGambit : CardSO
{
    public int damage = 10;
    public int[] chance = new int[3] {33, 34, 33};
    

    public override int[] DoAction(Unit actor, Unit enemy, out float timeSpent, int[] randomized = null) 
    {
        timeSpent = 2;

        if (base.sfx != null) SetAudioSound.instance.PlaySFX(base.sfx);

        if (randomized != null && randomized.Length != 1) { return null; }

        int index;

        if(randomized == null) index = Randomizer.random(chance);
        else index = randomized[0];

        switch(index) {
            case 0:
                actor.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"{actor.name} shot a gambit into himself, unlucky, he got shotted.");
                actor.ReduceHP(damage);
                break;

            case 1:
                actor.ChangeSprite(this, PoseCatagory.use);
                DialogueSystem.DisplayDialogue($"{actor.name} shot a gambit and no one got hit.");
                break;

            case 2:
                enemy.ChangeSprite(this, PoseCatagory.react1);
                DialogueSystem.DisplayDialogue($"{actor.name} shot a gambit into {enemy.name} his knee, goddamn.");
                enemy.ReduceHP(damage);
                break;

        }

        return new int[1] {index};
    }
}