using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Card", fileName = "New Attack Card")]
public class AttackCard: CardSO {
    public override void action() {
        Debug.Log("Attack");
    }
}
