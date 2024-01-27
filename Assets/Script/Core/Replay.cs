using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour
{
    public class ReplayTurn {
        public Unit actor;
        public Unit enemy;
        public CardSO move;
        public int[] randomized;

        public ReplayTurn(Unit _actor, Unit _enemy, CardSO _move, int[] _randomized) {
            actor = _actor;
            enemy = _enemy;
            move = _move;
            randomized = _randomized;
        }
    }

    private static Replay _instance;
    public static Replay get => _instance;

    private void Awake()
    {
        _instance = this;
    }

    List<ReplayTurn> replay;
    public Replay() {
        replay = new List<ReplayTurn>();
    }

    public void Record(Unit actor, Unit enemy, CardSO move, int[] randomized) {
        Debug.Log("Recorded");
        replay.Add(new ReplayTurn(actor, enemy, move, randomized));
    }

    public void PlayReplay() {
        Unit actor = replay[0].actor;
        Unit enemy = replay[0].enemy;

        actor.ResetState();
        actor.ResetStats();
        enemy.ResetState();
        enemy.ResetStats();
        
        StartCoroutine(IEReplay(1f));
    }

    private IEnumerator IEReplay(float delay) {
        yield return new WaitForSeconds(delay);

        for(int i = 0; i < replay.Count; i++) {
            CardSO currentMove = replay[i].move;
            currentMove.DoAction(replay[i].actor, replay[i].enemy, replay[i].randomized);
            yield return new WaitForSeconds(delay);
        }
    }
}
