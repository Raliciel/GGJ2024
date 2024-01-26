using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defend Card", fileName = "New Defend Card")]
public class DefendCard: CardSO {
    public override void action() {
        Debug.Log("Defend");
    }
}
