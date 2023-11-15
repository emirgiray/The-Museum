using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Image dialogueBox;

    //public float rotateTowards;//-11

    //public Transform target;
    //public float speed = 1.0f;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
            FindObjectOfType<FPSCamera>().enabled = false;          
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            dialogueBox.gameObject.SetActive(true);

            //Camera.main.transform.Rotate(rotateTowards, 0, 0);

            //Vector3 targetDirection = target.position - transform.position;

            //float singleStep = speed * Time.deltaTime;

            //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            //Camera.main.transform.Rotate(newDirection);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<FPSCamera>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            dialogueBox.gameObject.SetActive(false);
        }

    }
}
