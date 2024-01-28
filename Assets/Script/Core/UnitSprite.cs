using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(Unit))]
public class UnitSprite : MonoBehaviour
{
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite angrySprite;
    [SerializeField] Sprite happySprite;
    [SerializeField] Sprite deathSprite;
    SpriteRenderer sprite => GetComponent<SpriteRenderer>();
    Unit actor => GetComponent<Unit>();

    private void Start()
    {
        actor.OnLaugh += () => { ShowHappy(); };
        actor.OnDeath += () => { ShowDeath(); };
    }

    private void Update()
    {
        if (actor.unoccupied) return;
        if (actor.GetCurrentAngerPoint() < 50) ShowNormal();
        else ShowAngry();
    }
    public void ShowNormal()
    {
        if (sprite.sprite.Equals(normalSprite)) sprite.sprite = normalSprite;
    }
    public void ShowAngry()
    {
        if (sprite.sprite.Equals(angrySprite)) sprite.sprite = angrySprite;
    }
    public void ShowHappy()
    {
        sprite.sprite = happySprite;
    }

    float _time = 0;
    float duration = 5;

    public void ShowDeath()
    {
        sprite.sprite = deathSprite;
    }
}
