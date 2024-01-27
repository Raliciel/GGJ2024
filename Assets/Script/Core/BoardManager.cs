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

    private Camera _cam;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _cam = Camera.main;
        Turn.get.OnPlayerTurn += RandomDisplayCards;

        RandomDisplayCards(Turn.get.GetCurrentUnit());
    }

    private void HideAllCards()
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

    private IEnumerator UseCard(CardSO cardInfo, Unit actor, Unit target, float delay)
    {
        yield return new WaitForSeconds(delay);

        float timeSpend = 0.5f; //Will get from Do action of cardInfo
        Debug.Log(actor.name + " use " + cardInfo.cardName);
        cardInfo.DoAction(actor, target);

        yield return new WaitForSeconds(timeSpend);
        Turn.get.EndTurn();
    }

    public void UseCardOnBoard(CardSO cardInfo, CardUI card)
    {
        HideAllCards();

        Unit actor = Turn.get.GetCurrentUnit();
        Unit target = Turn.get.GetCurrentOpponentUnit();

        float timeOnAnimation = CardFlyAnimator.get.FlyCardToFront(cardInfo, card.transform.position, 2.2f);
        StartCoroutine(UseCard(cardInfo, actor, target, timeOnAnimation));
    }

    public void UseRandomCard()
    {
        HideAllCards();

        Unit actor = Turn.get.GetCurrentUnit();
        Unit target = Turn.get.GetCurrentOpponentUnit();
        CardSO card = RandomGetACard();

        float timeOnAnimation = CardFlyAnimator.get.FlyCardToFront(card, _cam.WorldToScreenPoint(actor.transform.position), 0.6f);
        StartCoroutine(UseCard(card, actor, target, timeOnAnimation));
    }

    public CardSO RandomGetACard()
    {
        int r = Random.Range(0, cardPool.Count);
        CardSO card = cardPool[r];
        //Random flavour and effect value here
        return card;
    }
}
