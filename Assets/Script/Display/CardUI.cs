using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    int _i;
    private CardSO _cardInfo;
    public TMP_Text name;
    public TMP_Text description;

    public void DisplayCard(int i, CardSO cardInfo)
    {
        _i = i;
        _cardInfo = cardInfo;
        SetText(name, _cardInfo.cardName);
        SetText(description, "Took the fun");
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

    private void SetText(TMP_Text display, string text)
    {
        display.text = text;  
    }
}
