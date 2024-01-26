using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardSO: ScriptableObject {
    public string cardName = "Card Name";
    public List<string> cardFlavor = new List<string>();
    public Sprite spriteAnimation;  //Should not be this, as animations may be implementeted
    //Animations are just sprite swappings so...
    /*
    public Sprite ngUse;
    public Sprite ngReact;
    public Sprite mfUse;
    public Sprite mfReact;
    */
    //uncomment this if everything is done.

    public abstract void DoAction(Unit actor, Unit target);
}

