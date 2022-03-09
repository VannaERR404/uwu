using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private float spawnTime;
    public float spawnRate; 
    void Start()
    {
        spawnTime = Time.timeSinceLevelLoad + spawnRate;
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad >= spawnTime)
        {
            Spawn();
            spawnTime = Time.timeSinceLevelLoad + spawnRate;
        }
    }
    void Spawn()
    {
        Instantiate(enemy,transform.position,transform.rotation);
    }
}
