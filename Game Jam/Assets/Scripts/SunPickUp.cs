using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPickUp : MonoBehaviour
{
    public GameObject sunPickup;
    public GameObject playerSun;
    public bool isSunPickedUp = false;
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
            sunPickup.SetActive(false);
            playerSun.SetActive(true);
            isSunPickedUp = true;
            //DontDestroyOnLoad( );
        }
    }
}
