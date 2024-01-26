using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StayHydrate", menuName = "Card/StayHydrate", order = 1)]
public class StayHydrate : CardSO
{
    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses Stay Hydrate.");
    }
}