using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    DialogueSystem instance;
    TMP_Text _dialogue => GetComponentInChildren<TMP_Text>();
    static TMP_Text dialogue;
    static GameObject self;
    DialogueMovement _dialog => GetComponent<DialogueMovement>();
    static DialogueMovement dialog;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        self = gameObject;
        dialogue = _dialogue;
        dialog = _dialog;
    }

    // Update is called once per frame
    public static void DisplayDialogue(string textToShow)
    {
        dialogue.text = textToShow;
        if (dialogue == null && dialog == null) return;
        dialog.MoveIn();
    }

    public static void HideDialogue()
    {
        if (dialogue == null && dialog == null) return;
        dialog.MoveOut();
    }
}
