using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected int healthPoint;
    [SerializeField] protected int angerPoint;
    // Update is called once per frame
    void Update()
    {
        if (Turn.GetCurrentUnit().gameObject.name.Equals(gameObject.name))
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
