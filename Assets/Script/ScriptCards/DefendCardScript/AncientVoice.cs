using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AncientVoice", menuName = "Card/AncientVoice", order = 1)]
public class AncientVoice : CardSO
{
    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses AncientVoice.");
    }
}