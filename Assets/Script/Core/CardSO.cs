using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

public enum PoseCatagory
{
    use,
    react1,
    react2
}

public abstract class CardSO: ScriptableObject {
    public string cardName;
    [TextArea(2, 6)]
    public List<string> cardFlavor = new List<string>();
    //public Sprite spriteAnimation;  //Should not be this, as animations may be implementeted
    //Animations are just sprite swappings so...

    [Header("NG Sprite")]
    public Sprite ngUse;
    public Sprite ngReact1;
    public Sprite ngReact2;
    [Header("MF Sprite")]
    public Sprite mfUse;
    public Sprite mfReact1;
    public Sprite mfReact2;

    [Header("Sound")]
    public AudioClip sfx;

    private bool assignOnce = false;
    
    //uncomment this if everything is done.

    public abstract int[] DoAction(Unit actor, Unit target, out float timeSpent, int[] randomized = null);

    public string GetFlavor()
    {
        if (cardFlavor == null || cardFlavor.Count == 0)
            return "No context";
        int r = UnityEngine.Random.Range(0, cardFlavor.Count);
        return cardFlavor[r];
    }
}

