using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardPool", menuName = "Card/CardPool", order = 1)]
public class CardPoolSO : ScriptableObject
{
    public List<CardSO> cards;

    public CardSO RandomGetACard()
    {
        int r = Random.Range(0, cards.Count);
        CardSO card = cards[r];
        return card;
    }
}
