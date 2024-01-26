using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    int _i;
    private CardSO _cardInfo;
    public TextMeshProUGUI textDisplayer;

    public void DisplayCard(int i, CardSO cardInfo)
    {
        _i = i;
        _cardInfo = cardInfo;
        SetText(_cardInfo.cardName);
        gameObject.SetActive(true);
    }

    public void HideCard()
    {
        gameObject.SetActive(false);
    }

    public void OnCardSelected()
    {
        if (_cardInfo == null)
            return;

        BoardManager.get.UseCard(_cardInfo);
    }

    private void SetText(string text)
    {
        textDisplayer.text = text;  
    }
}
