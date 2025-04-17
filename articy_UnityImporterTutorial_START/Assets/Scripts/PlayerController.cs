using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private string dialogue;
    private string speaker;

    private float speed = 15f;
    private bool isNearNPC = false;

    private Rigidbody playerRB;
    private DialogueManager dialogueManager;
 
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        PlayerInteraction();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    // Simple player movement
    void PlayerMovement()
    {
        // Remove movement control while in dialogue
        if (dialogueManager.DialogueActive)
            return;

        playerRB.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
    }

    // All interactions and key inputs player can use
    void PlayerInteraction()
    {
        // Key option to start dialogue when near NPC
        if (Input.GetKeyDown(KeyCode.Space) && isNearNPC)
        {
            dialogueManager.StartDialogue(dialogue, speaker);
        }

        // Key option to abort dialogue
        if (dialogueManager.DialogueActive && Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.CloseDialogueBox();
        }

        // Key option to reset entire scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    // Simple scene restart for testing purposes
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Trigger Enter/Exit used to determine if interaction with NPC is possible
    void OnTriggerEnter(Collider aOther)
    {
        isNearNPC = true;

        // get dialogue line and speaker name from triggered object
        dialogue = aOther.GetComponent<DialogueHolder>().dialogueLine;
        speaker = aOther.GetComponent<DialogueHolder>().speakerName;
    }

    void OnTriggerExit(Collider aOther)
    {
        isNearNPC = false;
    }
}
