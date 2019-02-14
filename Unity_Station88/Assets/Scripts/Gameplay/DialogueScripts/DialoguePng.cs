using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePng : MonoBehaviour {

    DialogueTrigger trigger;


    bool hasStarted = false;

    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxis("Vertical")> 0 && collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            trigger.TriggerDialogue();
            hasStarted = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            DialogueSystem dialogueS = FindObjectOfType<DialogueSystem>();
            dialogueS.DisplayNextSentence();
        }
    }
}
