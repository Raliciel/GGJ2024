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
        if (sprite.sprite != normalSprite) sprite.sprite = normalSprite;
    }
    public void ShowAngry()
    {
        if (sprite.sprite != angrySprite) sprite.sprite = angrySprite;
    }
    public void ShowHappy()
    {
        sprite.sprite = happySprite;
        ShowHappyAura();
    }

    float _time = 0;
    float duration = 5;
    private void ShowHappyAura()
    {
        GameObject shadow = new GameObject();
        shadow.transform.parent = transform.parent;
        shadow.transform.SetAsFirstSibling();
        shadow.AddComponent<SpriteRenderer>();
        shadow.GetComponent<SpriteRenderer>().sprite = sprite.sprite;
        while (_time < duration)
        {
            Vector4 color = new Vector4(2, 211, 118, 100);
            shadow.GetComponent<SpriteRenderer>().color = color;
            shadow.transform.localScale = Vector3.one * _time;
            _time += Time.deltaTime;
        }
        Destroy(shadow);
        
        
    }

    public void ShowDeath()
    {
        sprite.sprite = deathSprite;
    }
}
