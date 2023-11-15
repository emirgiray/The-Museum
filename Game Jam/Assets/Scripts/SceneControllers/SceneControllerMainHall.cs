using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneControllerMainHall : MonoBehaviour
{
    bool trigger = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = false;
        }
    }

    void Update()
    {
        if (trigger && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Main Hall");
        }
    }
}
