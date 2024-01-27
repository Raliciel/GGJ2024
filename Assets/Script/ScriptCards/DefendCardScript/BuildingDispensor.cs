using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDispensor", menuName = "Card/Defend/BuildingDispensor", order = 1)]
public class BuildingDispensor : CardSO
{
    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses Building a Dispensor.");
    }
}