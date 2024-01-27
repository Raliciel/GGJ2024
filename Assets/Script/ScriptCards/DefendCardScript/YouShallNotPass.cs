using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "YouShallNotPass", menuName = "Card/Defend/YouShallNotPass", order = 1)]
public class YouShallNotPass : CardSO
{
    public override void DoAction(Unit actor, Unit enemy)
    {
        Debug.Log(actor.name + " uses YouShallNotPass.");
    }
}