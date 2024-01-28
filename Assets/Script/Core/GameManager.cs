using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum EndType { hp, anger}

    public Unit playerUnit;
    public Unit enemyUnit;
    public GameObject hpEndingCanvasPref;
    public GameObject angerEndingCanvasPref;
    public GameObject endingPad;

    private static GameManager _instance;
    public static GameManager get => _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartGame();

        playerUnit.OnDeath += () => { OnUnitDeath(enemyUnit, playerUnit); };
        enemyUnit.OnDeath += () => { OnUnitDeath(playerUnit, enemyUnit); };
        playerUnit.OnLaugh += () => { OnUnitLaugh(enemyUnit, playerUnit); };
        enemyUnit.OnLaugh += () => { OnUnitLaugh(playerUnit, enemyUnit); };
    }
    private void EndGame(Unit winner = null, EndType ending = EndType.hp)
    {
        Turn.get.StopTurn();
        StartCoroutine(DelayedEnd(winner, ending));
    }

    IEnumerator DelayedEnd(Unit winner, EndType ending)
    {
        yield return new WaitForSeconds(1f);

        if (ending == EndType.hp)
        {
            Instantiate(hpEndingCanvasPref);
            SetAudioSound.instance.PlayBGMByIndex(3);
        }
        else
        {
            Instantiate(angerEndingCanvasPref);
            SetAudioSound.instance.PlayBGMByIndex(2);
        }

        TMP_Text retryText = endingPad.transform.GetChild(0).GetComponentInChildren<TMP_Text>();
        if (winner == playerUnit) retryText.text = "Next Battle";
        else retryText.text = "Fight Again";
        endingPad.SetActive(true);
    }
    public void Restart()
    {
        Replay.get.ClearReplay();
        StartGame();
    }
    public void OnUnitDeath(Unit winner, Unit loser)
    {
        Debug.Log(winner.name + " win!, on death");
        EndGame(winner,EndType.hp);
    }
    public void OnUnitLaugh(Unit winner, Unit loser)
    {
        Debug.Log(winner.name + " win!, on laugh");
        EndGame(winner, EndType.anger);
    }

    private void StartGame()
    {
        SetAudioSound.instance.PlayBGMByIndex(1);
        //CardFlyAnimator.get.ClearFalledCards();
        Turn.get.InitTurnUnits(playerUnit,enemyUnit);
        playerUnit.ResetState();
        enemyUnit.ResetState();
        playerUnit.ResetStats();
        enemyUnit.ResetStats();
        endingPad.SetActive(false);
    }
}
