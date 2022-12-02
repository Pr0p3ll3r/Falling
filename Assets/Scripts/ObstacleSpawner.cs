using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float timer;
    [SerializeField] private float timeToSpawn = 5f;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;
    private ObjectPooler pooler;
    private float timeToSpawnBase;

    private void OnEnable()
    {
        Obstacle.OnGameOver += StopSpawning;
        GameManager.OnStartGame += StartSpawning;
    }

    void Start()
    {
        timeToSpawnBase = timeToSpawn;
        pooler = GetComponent<ObjectPooler>();
        enabled = false;
    }

    void Update()
    {
        if (timer <= 0)
        {
            SpawnObstacle();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }  
    
    void SpawnObstacle()
    {
        GameObject newObstacle = pooler.GetObject();
        newObstacle.transform.position = transform.position + new Vector3(Random.Range(maxLeft, maxRight), -7, 0);
        newObstacle.SetActive(true);
        if(timeToSpawn > 0.2f) timeToSpawn -= 0.2f;
        timer = timeToSpawn; 
    }

    void StartSpawning()
    {
        timeToSpawn = timeToSpawnBase;
        timer = timeToSpawn;
        enabled = true;
    }

    void StopSpawning()
    {
        enabled = false;
    }
}
