using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    int _i;
    [SerializeField] private CardSO _cardInfo;
    public GameObject cardObj;
    public new TMP_Text name;
    public TMP_Text description;
    private string _flavor;

    float originalY = 0;

    private void Awake()
    {
        originalY = cardObj.transform.localPosition.y;
    }

    public void DisplayCard(int i, CardSO cardInfo, string flavor = null)
    {
        _i = i;
        GetComponent<Button>().interactable = i > -1;
        _cardInfo = cardInfo;
        SetText(name, _cardInfo.cardName);
        if (flavor == null)
            _flavor = _cardInfo.GetFlavor();
        else
            _flavor = flavor;
        SetText(description, _flavor);
        gameObject.SetActive(true);
    }

    public string GetFlavor()
    {
        return _flavor;
    }

    public void HideCard()
    {
        gameObject.SetActive(false);
        ReturnCard();
    }

    public void OnCardSelected()
    {
        if (_cardInfo == null)
            return;

        BoardManager.get.UseCardOnBoard(_cardInfo, this);
    }

    private void SetText(TMP_Text display, string text)
    {
        display.text = text;  
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (_i == -1)
            return;
        Transform t = cardObj.transform;
        if (t.localPosition.y > originalY)
            t.localPosition = new Vector3(t.localPosition.x, originalY, t.localPosition.z);
        cardObj.LeanMoveLocalY(t.localPosition.y + 100, 0.25f).setEaseOutBack();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (_i == -1)
            return;
        ReturnCard();
    }

    void ReturnCard()
    {
        LeanTween.cancel(cardObj);
        cardObj.LeanMoveLocalY(originalY, 0.25f);
    }
}
