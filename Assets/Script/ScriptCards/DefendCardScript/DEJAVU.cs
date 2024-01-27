using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DEJAVU", menuName = "Card/Defend/DEJAVU", order = 1)]
public class DEJAVU : CardSO
{
    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses DEJAVU.");
    }
}