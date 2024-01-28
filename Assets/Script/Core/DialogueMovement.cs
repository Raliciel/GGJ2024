using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMovement : MonoBehaviour
{
    [SerializeField] Transform centerTransform;
    static bool unoccupied = false;

    public void Awake()
    {
        gameObject.SetActive(false);
    }
    public void MoveIn()
    {
        if (unoccupied) return;
        unoccupied = true;
        gameObject.transform.localScale = Vector3.one * 0.5f;
        gameObject.transform.LeanScale(Vector3.one,0.3f).setEaseOutBack().setOnComplete(() => { gameObject.SetActive(true); });
        unoccupied = false;
    }

    public void MoveOut()
    {
        if (unoccupied) return;
        unoccupied = true;
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.LeanScale(Vector3.one * 0.5f, 0.3f).setEaseInBack().setOnComplete(() => { gameObject.SetActive(false); }) ;
        unoccupied = false;
    }
}
