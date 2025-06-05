using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // componente UI que vai aparecer o texto setado no script object
    public GameObject dialoguePanel; // Painel de diálogo para ativar/desativar 

    private DialogueSO currentDialogue; //variável que armazena o dialogo atual
    private int currentLineIndex = 0; 
    private bool isDialogueActive = false;

    public DialogueSO welcomeDialogue; // assign no inspector

    private void Start()
    {
        StartDialogue(welcomeDialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextLine();
            }
        }
    }

    public void StartDialogue(DialogueSO dialogue)
    {
        currentDialogue = dialogue;
        currentLineIndex = 0;
        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        ShowLine();
    }

    void ShowLine()
    {
        if (currentLineIndex < currentDialogue.lines.Length)
        {
            dialogueText.text = currentDialogue.lines[currentLineIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    void NextLine()
    {
        currentLineIndex++;
        ShowLine();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
    }
}
