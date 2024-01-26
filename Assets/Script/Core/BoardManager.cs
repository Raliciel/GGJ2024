using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public List<CardUI> cardUIs = new List<CardUI>();
    public List<CardSO> cardPool = new List<CardSO>();
    public GameObject cardPanel;

    private static BoardManager _instance;
    public static BoardManager get => _instance;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Turn.get.OnChangeTurn += HideAllCards;
        Turn.get.OnPlayerTurn += RandomDisplayCards;

        RandomDisplayCards(Turn.get.GetCurrentUnit());
    }

    private void HideAllCards(Unit turnOwnerUnit)
    {
        for (int i = 0; i < cardUIs.Count; i++)
            cardUIs[i].HideCard();
        cardPanel.SetActive(false);
    }

    private void RandomDisplayCards(Unit playerUnit)
    {
        //Assume we have 5 cards
        for(int i =0; i < cardUIs.Count; i++)
        {
            cardUIs[i].DisplayCard(i, RandomGetACard());
        }
        cardPanel.SetActive(true);
    }

    public void UseCard(CardSO cardInfo)
    {
        Unit actor = Turn.get.GetCurrentUnit();
        Unit target = Turn.get.GetCurrentOpponentUnit();
        Debug.Log(actor.name + " use " + cardInfo.cardName);
        cardInfo.DoAction(actor, target);

        //If normal condition, no double card
        Turn.get.EndTurn();
    }
    public void UseRandomCard()
    {
        UseCard(RandomGetACard());
    }

    public CardSO RandomGetACard()
    {
        int r = Random.Range(0, cardPool.Count);
        CardSO card = cardPool[r];
        //Random flavour and effect value here
        return card;
    }
}
