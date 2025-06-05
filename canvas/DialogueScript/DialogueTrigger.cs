using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSO dialogue;
    private bool triggered = false;

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogue);
            triggered = true;
        }
    }
}
