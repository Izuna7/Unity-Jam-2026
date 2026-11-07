using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public DialogueManager dialogueManager; // Reference to the DialogueManager

    [SerializeField] private Image characterImage; // Reference to the Image component for character image
    [SerializeField] private TextMeshProUGUI characterNameText; // Reference to the TextMeshProUGUI for character name
    [SerializeField] private TextMeshProUGUI dialogueText; // Reference to the TextMeshProUGUI for dialogue text
    [SerializeField] private float typingSpeed = 0.05f; // Speed at which the dialogue text is typed out
    private Coroutine typingCoroutine;

    public UnityEvent OnDialogueStart; // Event triggered when dialogue starts
    public UnityEvent OnDialogueEnd; // Event triggered when dialogue ends
    public void UpdateDialogueUI(DialogueSO dialogue) // Method to update the dialogue UI with the current dialogue
    {
        if (dialogue != null)
        {
            OnDialogueStart.Invoke(); // Trigger the OnDialogueStart event when dialogue starts
            ClearDialogue();

            characterImage.sprite = dialogue.characterImage;
            characterNameText.text = dialogue.characterName;
            dialogueText.text = dialogue.dialogue;
        }
    }
    public bool IsTyping => typingCoroutine != null;
    public void StartTyping() // Starts the typewriter effect with the loaded dialogue
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        typingCoroutine = StartCoroutine(TypeDialogue(dialogueText.text));
    }
    public void SkipTyping() // Shows the full dialogue text immediately
    {
        if (typingCoroutine == null)
        {
            return;
        }
        StopCoroutine(typingCoroutine);
        typingCoroutine = null;
        dialogueText.maxVisibleCharacters = dialogueText.text.Length;
        OnDialogueEnd.Invoke();
    }
    private IEnumerator TypeDialogue(string text) 
    {
        dialogueText.text = text;
        dialogueText.maxVisibleCharacters = 0;
        for (int i = 1; i <= text.Length; i++)
        {
            dialogueText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }
        typingCoroutine = null;
        OnDialogueEnd.Invoke(); // Trigger the OnDialogueEnd event when typing is complete
    }
    public void ClearDialogue() // Stops typing and clears the texts so they don't show up at once next time
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        characterImage.sprite = null;
        characterNameText.text = "";
        dialogueText.text = "";
        dialogueText.maxVisibleCharacters = 0;
    }

}
