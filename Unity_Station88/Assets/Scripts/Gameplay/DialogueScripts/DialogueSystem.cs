using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    PlayerPlatformerController player;
    public Queue<string> sentences;
    [SerializeField]
    GameObject dialogueBox;
    [SerializeField]
    Text characterNameBox;
    [SerializeField]
    Text dialogueTextBox;

    void Start () {
        sentences = new Queue<string>();
        player = GetComponent<PlayerPlatformerController>();
	}

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting dialogue with" + dialogue.name);
        dialogueBox.SetActive(true);
        characterNameBox.text = "";

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("Dialogue End");
    }
}