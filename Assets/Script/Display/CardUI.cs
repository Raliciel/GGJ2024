using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;

public class CardUI : MonoBehaviour
{
    int _i;
    [SerializeField] private CardSO _cardInfo;
    public new TMP_Text name;
    public TMP_Text description;

    public void DisplayCard(int i, CardSO cardInfo)
    {
        _i = i;
        _cardInfo = cardInfo;
        SetText(name, _cardInfo.cardName);
        if (_cardInfo.cardFlavor.Count == 0) SetText(description, "No context");
        else SetText(description, _cardInfo.cardFlavor[(int)Random.Range(0, _cardInfo.cardFlavor.Count-1)]);
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
