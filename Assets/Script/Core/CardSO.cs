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
    public List<string> cardFlavor = new List<string>();
    //public Sprite spriteAnimation;  //Should not be this, as animations may be implementeted
                                    //Animations are just sprite swappings so...

    public Sprite ngUse;
    public Sprite ngReact1;
    public Sprite ngReact2;
    public Sprite mfUse;
    public Sprite mfReact1;
    public Sprite mfReact2;

    private bool assignOnce = false;
    
    //uncomment this if everything is done.

    public abstract void DoAction(Unit actor, Unit target);

    public void OnEnable()
    {
        if (assignOnce) return;
        cardName = this.name;
        Debug.Log("Create: " +  cardName);
        ngUse = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprite/NG/NG.png");
        ngReact1 = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprite/NG/NG.png");
        ngReact2 = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprite/NG/NG.png");
        mfUse = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprite/NG/NG.png");
        mfReact1 = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprite/NG/NG.png");
        mfReact2 = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprite/NG/NG.png");
        assignOnce = true;
    }

    public string GetFlavor()
    {
        if (cardFlavor == null || cardFlavor.Count == 0)
            return "No context";
        int r = UnityEngine.Random.Range(0, cardFlavor.Count);
        return cardFlavor[r];
    }

     protected void ChangeSprite(Unit actor, PoseCatagory pose)
    {
        actor.ChangeSprite(this, pose);
    }
}

