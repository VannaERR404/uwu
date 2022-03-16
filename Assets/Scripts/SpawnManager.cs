using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private float spawnTime;
    public float spawnRate;
    public GameObject[] spawners;
    private GameObject spawnPoint;
    private int n;
    void Start()
    {
        spawnTime = Time.timeSinceLevelLoad + spawnRate;
        spawners = GameObject.FindGameObjectsWithTag("spawner");
        n = Random.Range(0, spawners.Length);
        spawnPoint = spawners[n];
    }


    void Update()
    {
        if (Time.timeSinceLevelLoad >= spawnTime)
        {
            spawnTime = Time.timeSinceLevelLoad + spawnRate;
            Spawn();
        }
    }
    void Spawn()
    { 
        GameObject.Instantiate(enemy, spawnPoint.GetComponent<Transform>().position, transform.rotation);
        n = Random.Range(0, spawners.Length);
        spawnPoint = spawners[n];
    }
    


}
