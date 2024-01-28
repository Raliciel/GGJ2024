using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Unit playerUnit;
    public Unit enemyUnit;
    public GameObject endingCanvasPref;
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
        playerUnit.OnLaugh += () => { OnUnitDeath(enemyUnit, playerUnit); };
        enemyUnit.OnLaugh += () => { OnUnitDeath(playerUnit, enemyUnit); };
    }
    public void EndGame(Unit winner = null)
    {
        Turn.get.StopTurn();
        StartCoroutine(DelayedEnd(winner));
    }

    IEnumerator DelayedEnd(Unit winner)
    {
        yield return new WaitForSeconds(1f);
        Instantiate(endingCanvasPref);

        TMP_Text retryText = endingPad.transform.GetChild(0).GetComponentInChildren<TMP_Text>();
        if (winner == playerUnit) retryText.text = "Next Battle";
        else retryText.text = "Fight Again";
        endingPad.SetActive(true);
    }
    public void Restart()
    {
        StartGame();
    }
    public void OnUnitDeath(Unit winner, Unit loser)
    {
        Debug.Log(winner.name + " win!, on death");
        EndGame(winner);
    }

    private void StartGame()
    {
        //CardFlyAnimator.get.ClearFalledCards();
        Turn.get.InitTurnUnits(playerUnit,enemyUnit);
        playerUnit.ResetState();
        enemyUnit.ResetState();
        playerUnit.ResetStats();
        enemyUnit.ResetStats();
        endingPad.SetActive(false);
    }
}
