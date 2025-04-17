using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;

public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks
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

    private ArticyFlowPlayer flowPlayer;

    void Start()
    {
        flowPlayer = GetComponent<ArticyFlowPlayer>();
    }
    
    public void StartDialogue(IArticyObject aObject)
    {
        DialogueActive = true;
        dialogueWidget.SetActive(DialogueActive);
        flowPlayer.StartOn = aObject;

    }

    public void CloseDialogueBox()
    {
        DialogueActive = false;
        dialogueWidget.SetActive(DialogueActive);        
    }

    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        dialogueText.text = string.Empty;
        var objectWithText = aObject as IObjectWithText;
        if (objectWithText != null)
        {
            dialogueText.text = objectWithText.Text;
        }
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        
    }
}
