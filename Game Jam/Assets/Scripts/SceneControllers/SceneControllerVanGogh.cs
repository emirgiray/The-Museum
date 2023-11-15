using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneControllerVanGogh : MonoBehaviour
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
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
    //    {
    //        SceneManager.LoadScene("Van Gogh");
    //    }
    //}
    private void Start()
    {
        
    }
    void Update()

    {
        //var trigger2 = FindObjectOfType<SunPickUp>().isSunPickedUp;
        if (trigger && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Van Gogh 2");
        }
        
        if (trigger && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Van Gogh");
        }
    }
}
