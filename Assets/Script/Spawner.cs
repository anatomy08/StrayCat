using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float secondsBetweenEnemy = 1.5f;
    [SerializeField] Vector2 forceRange;

    float timer; 
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        
    }
    
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 )
        {
            SpawnEnemy();

            timer += secondsBetweenEnemy;
        }

    }

    void SpawnEnemy()
    {
        int side = Random.Range(0, 4); // 0 to 3.

        Vector2 spawnPoint = Vector2.zero; // direction of spawn point 0 0 0
        Vector2 direction = Vector2.zero; // direction of enemy after spawn


        switch(side)
        {
            case 0: // Left Spawn
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1: // Bottom spawn
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f,1f), 1f);
                break;
            case 2: // Right Spawn
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 3:
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f),-1f);
                break;    
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject EnemyInstance = Instantiate(selectedEnemy, worldSpawnPoint, Quaternion.Euler(-90f,0f,0f));

        Rigidbody rb = EnemyInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x , forceRange.y);

        
    }
}
