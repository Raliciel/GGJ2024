using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMovement : MonoBehaviour
{
    [SerializeField] Transform centerTransform;
    static bool unoccupied = false;
    // Start is called before the first frame update

    public void Awake()
    {
        gameObject.SetActive(true);
    }
    public void MoveIn()
    {
        if (unoccupied) return;
        unoccupied = true;
        gameObject.transform.LeanMove(centerTransform.position - Vector3.up * 1000, 0);
        gameObject.transform.LeanMoveLocalY(centerTransform.position.y -400, .5f).setDelay(0.7f).setEaseInBack();
        unoccupied = false;
    }

    public void MoveOut()
    {
        if (unoccupied) return;
        unoccupied = true;
        gameObject.transform.LeanMove(centerTransform.position - Vector3.up * 400, 0);
        gameObject.transform.LeanMoveLocalY(centerTransform.position.y - 1000, .5f).setDelay(0.7f).setEaseInBack();
        unoccupied = false;
    }
}
