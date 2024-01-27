using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlyAnimator : MonoBehaviour
{
    public GameObject cardPref;
    public Transform centerTransform;

    private Canvas canvas;

    private static CardFlyAnimator _instance;
    public static CardFlyAnimator get => _instance;


    private void Awake()
    {
        _instance = this;
        canvas = FindObjectOfType<Canvas>();
    }

    public float FlyCardToFront(CardSO cardInfo, Vector3 startPosition, float startSize)
    {
        CardUI card = Instantiate(cardPref, canvas.transform).GetComponent<CardUI>();
        card.transform.position = startPosition;
        card.transform.localScale = Vector3.one * startSize;
        card.DisplayCard(-1,cardInfo);

        card.transform.LeanMove(centerTransform.position, 0.25f);
        card.gameObject.LeanScale(Vector3.one * 2.4f, 0.5f).setDelay(0.2f).setEaseOutBack();
        card.transform.LeanMoveLocalY(centerTransform.position.y + 1000, .5f).setDelay(0.7f).setEaseInBack();

        return 1;
    }
}
