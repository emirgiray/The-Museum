using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerMunch : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;
    public float count = 0;
    public Button continueButton;
    public Button hopeButton;
    public Button deathButton;

    private Queue<string> sentences;
    //public Animator animator;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        nameText.text = dialogue.Name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();


    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (count == 2)
        {
            continueButton.gameObject.SetActive(false);

            hopeButton.gameObject.SetActive(true);
            deathButton.gameObject.SetActive(true);
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        count++;
    }
    public void HopeButton()
    {
        continueButton.gameObject.SetActive(true);
        hopeButton.gameObject.SetActive(false);
        deathButton.gameObject.SetActive(false);
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        FindObjectOfType<CameraShake>().isShakeEnabled = false;
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        FindObjectOfType<FPSCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<DialogueTriggerMunch>().dialogueBox.gameObject.SetActive(false);
    }
}
