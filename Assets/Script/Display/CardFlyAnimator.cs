using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlyAnimator : MonoBehaviour
{
    public GameObject cardPref;
    [Header("Upward anim")]
    public Transform centerTransform;
    public float centerScale = 3f;
    public float centerDelay = 1f;

    [Header("Downward anim")]
    public float backHeight = -160f;
    public float backScale = 0.5f;

    public Canvas overlayCanvas;
    public Canvas bgCanvas;

    private static CardFlyAnimator _instance;
    public static CardFlyAnimator get => _instance;

    private List<CardUI> _cards = new List<CardUI>();

    private void Awake()
    {
        _instance = this;
    }

    public float FlyCardToFront(CardSO cardInfo, Vector3 startPosition, float startSize, string flavor = null)
    {
        CardUI card = Instantiate(cardPref, overlayCanvas.transform).GetComponent<CardUI>();
        card.transform.position = startPosition;
        card.transform.localScale = Vector3.one * startSize;
        if(flavor == null)
            card.DisplayCard(-1,cardInfo);
        else
            card.DisplayCard(-1, cardInfo, flavor);

        card.transform.LeanMove(centerTransform.position, 0.25f);
        card.gameObject.LeanScale(Vector3.one * 2.4f, 0.5f).setDelay(0.2f).setEaseOutBack();
        card.transform.LeanMoveLocalY(centerTransform.position.y + 1000, .5f).setDelay(0.7f).setEaseInBack()
            .setOnComplete(() => { FallTheCard(card); });

        return 1 + centerDelay;
    }

    private void FallTheCard(CardUI card)
    {
        card.transform.SetParent(bgCanvas.transform);
        float x = Random.Range(-960, 960);
        card.transform.localPosition = new Vector3(x,1200,0);
        card.transform.localScale = Vector3.one * backScale;
        card.transform.LeanMoveLocalY(backHeight, 0.4f);
        _cards.Add(card);
    }

    public void ClearFalledCards()
    {
        for(int i = 0; i < _cards.Count; i++)
        {
            Destroy(_cards[i]);
        }
    }
}
