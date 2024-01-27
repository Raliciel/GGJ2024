using UnityEngine;
[CreateAssetMenu(fileName = "InternDesign", menuName = "Card/Special/InternDesign", order = 1)]

public class InternDesign: CardSO 
{
    public override void DoAction(Unit actor, Unit enemy) {
        Debug.Log($"Upon interference of some interns, {actor.name} Hp and Anger are reseted");
        actor.SetCurrentAngerPoint(actor.angerPoint);
        actor.SetCurrentHealthPoint(actor.healthPoint);
    }
}