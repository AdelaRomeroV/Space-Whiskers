using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCs : MonoBehaviour
{
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineaIndex;

    private float typingTime = 0.05f;

    [SerializeField] private GameObject alertDialogo;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLine;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }

            else if (dialogueText.text == dialogueLine[lineaIndex])
            {
                NexDialogueLine();
            }

            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLine[lineaIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        alertDialogo.SetActive(false);
        lineaIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NexDialogueLine()
    {
        lineaIndex++;
        if (lineaIndex < dialogueLine.Length)
        {
            StartCoroutine(ShowLine());
        }

        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            alertDialogo.SetActive(true);
            Time.timeScale = 1f;
        }

    }
    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLine[lineaIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            alertDialogo.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            alertDialogo.SetActive(false);
        }
    }
}
