using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInteract : MonoBehaviour
{
    bool trigger = false;
    public bool isEyeFound = false;
    public float speed = 2;

    public AudioSource Ses; //for sound of drawer

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
    void Start()
    {
        isEyeFound = false;
    }

    void Update()
    {
        if (trigger && Input.GetKey(KeyCode.E))
        {
            isEyeFound = true;
            //transform.position = new Vector3(-1, 0, -1) * speed * Time.deltaTime;
            Vector3 target = new Vector3(-74.732f, 0, -1.225f);
            transform.position =  Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime) ;

            Ses.Play(); //triggering it
        }
    }
}
