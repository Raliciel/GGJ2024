using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardSO: ScriptableObject {
    public string cardName = "Card Name";
    public List<string> cardFlavor = new List<string>();
    public Sprite spriteAnimation;  //Should not be this, as may be an animation not single sprite

    public abstract void DoAction(Unit actor, Unit target);
}

