using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    // Reference to Dialog UI
    [SerializeField]
    GameObject dialogueWidget;
    // Reference to dialogue text
    [SerializeField]
    Text dialogueText;
    // Reference to speaker
    [SerializeField]
    Text dialogueSpeaker;

    // To check if we are currently showing the dialog ui interface
    public bool DialogueActive { get; set; }

    void Start()
    {
        
    }
    
    public void StartDialogue(string aDialogueLine, string aSpeaker)
    {
        DialogueActive = true;
        dialogueWidget.SetActive(DialogueActive);       
        
        dialogueText.text = aDialogueLine;
        dialogueSpeaker.text = aSpeaker;
    }

    public void CloseDialogueBox()
    {
        DialogueActive = false;
        dialogueWidget.SetActive(DialogueActive);        
    }
}
