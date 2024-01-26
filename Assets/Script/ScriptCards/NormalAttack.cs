using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack: CardSO {
    [SerializeField] string cardName;
    [SerializeField] List<string> cardFlavor = new List<string>();
    [SerializeField] Sprite spriteAnimation;

    public override void action(Unit actor, Unit enemy) {
        enemy.SetCurrentHealthPoint(enemy.GetCurrentHealthPoint() - 10);
        enemy.SetCurrentAngerPoint(enemy.GetCurrentAngerPoint() + 3);
    }
}
