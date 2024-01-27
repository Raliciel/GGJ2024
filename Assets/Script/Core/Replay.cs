using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour
{
    public class ReplayTurn {
        Unit actor;
        Unit enemy;
        CardSO move;
        int[] randomized;

        public ReplayTurn(Unit _actor, Unit _enemy, CardSO _move, int[] _randomized) {
            actor = _actor;
            enemy = _enemy;
            move = _move;
            randomized = _randomized;
        }
    }

    List<ReplayTurn> replay;
    public Replay() {
        replay = new List<ReplayTurn>();
    }

    public void Record(Unit actor, Unit enemy, CardSO move, int[] randomized) {
        replay.Add(new ReplayTurn(actor, enemy, move, randomized));
    }

    public void PlayReplay() {
        //not implemented yet
    }
}
