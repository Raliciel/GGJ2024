using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    static Unit turnOwner;
    [SerializeField] Unit player;
    [SerializeField] Unit enemy;
    // Start is called before the first frame update
    private void Start()
    {
        turnOwner = player;
    }

    // Update is called once per frame
    public static Unit GetCurrentUnit()
    {
        return turnOwner;
    }

    public void ChangeTurn()
    {
        if (turnOwner.gameObject.name.Equals("Player"))
        {
            turnOwner = enemy;
        }
        else
        {
            turnOwner = player;
        }
    }
}
