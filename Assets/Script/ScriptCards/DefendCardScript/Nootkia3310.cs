using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nootkia3310", menuName = "Card/Defend/Nootkia3310", order = 1)]
public class Nootkia3310 : CardSO
{
    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses Nootkia3310.");
    }
}