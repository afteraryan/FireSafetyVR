using UnityEngine;

[CreateAssetMenu(fileName = "DialogueManager", menuName = "AI/DialogueManager")]
public class DialogueManager : ScriptableObject
{
    [System.Serializable]
    public class Dialogue
    {
        public AiState state;
        public AudioClip clip;
    }

    public Dialogue[] dialogues;

    public AudioClip GetDialogue(AiState state)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            if (dialogue.state == state)
            {
                Debug.Log("Dialogue: " + state);
                return dialogue.clip;
            }
        }

        return null;
    }
}
