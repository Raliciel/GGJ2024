using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turn : MonoBehaviour
{
    private Unit turnOwner;

    private Unit player;
    private Unit enemy;
    // Start is called before the first frame update

    public UnityAction<Unit> OnChangeTurn;
    public UnityAction<Unit> OnPlayerTurn;

    private static Turn _instance;
    public static Turn get => _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void InitTurnUnits(Unit playerUnit, Unit enemyUnit)
    {
        player = playerUnit;
        enemy = enemyUnit;

        SetTurn(player);
    }

    public Unit GetCurrentUnit()
    {
        return turnOwner;
    }

    public Unit GetCurrentOpponentUnit()
    {
        if (GetCurrentUnit() == player)
            return enemy;
        else
            return player;
    }

    public void EndTurn()
    {
        turnOwner = GetCurrentOpponentUnit();
        if(turnOwner.getIsDefend()) turnOwner.setIsDefend(false);
        OnChangeTurn?.Invoke(turnOwner);
        if(turnOwner == player)
            OnPlayerTurn?.Invoke(turnOwner);
    }

    public void SetTurn(Unit unit)
    {
        turnOwner = unit;
        OnChangeTurn?.Invoke(turnOwner);
        if (turnOwner == player)
            OnPlayerTurn?.Invoke(turnOwner);
    }
}
