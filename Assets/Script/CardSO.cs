using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardSO: ScriptableObject {
    [SerializeField] string cardName = "Card Name";
    [SerializeField] List<string> cardFlavor = new List<string>();
    [SerializeField] Sprite spriteAnimation;

    public abstract void action();
}

