using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Scriptable Objects/DialogueSO")]
public class DialogueSO : ScriptableObject
{
    public string characterName;
    [TextArea(3, 10)]
    public string dialogue;
    public Sprite characterImage; // Optional: Add a character image for the dialogue
    public AudioClip voiceClip; // Optional: Add a voice clip for the dialogue
}
