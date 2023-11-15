using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public float targetX;
    public float targetZ;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 target = new Vector3(targetX, 0, targetZ);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deathwall"))
        {
            Destroy(gameObject );
           // DestroyGameObject();
        }
    }
    //void DestroyGameObject()
    //{
    //    Destroy(gameObject);
    //}
}
