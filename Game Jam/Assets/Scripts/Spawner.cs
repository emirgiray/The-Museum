using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;   
    public float spawnDelay = 3;
    float timeSinceLastSpawn = 0;
    void Start()
    {

    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
            GameObject monster = Instantiate<GameObject>(Enemy, gameObject.transform.position, gameObject.transform.rotation);
            
            timeSinceLastSpawn = 0;

        }

    }
    //void Start()
    //{

    //}
    //void Update()
    //{
    //    StartCoroutine(SpawnTimer(5));
    //    Invoke(nameof(SpawnTimer), 5);
    //}
    //IEnumerator SpawnTimer(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    Instantiate(Enemy);
    //}
}
