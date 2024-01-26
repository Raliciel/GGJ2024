using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Special Card", fileName = "New Special Card")]
public class SpecialCard: CardSO {
    public override void action() {
        Debug.Log("Special");
    }
}
