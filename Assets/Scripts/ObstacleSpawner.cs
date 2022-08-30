using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private float timer;
    [SerializeField] private float timeToSpawn = 5f;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;

    void Start()
    {
        SpawnObstacle();
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
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = transform.position + new Vector3(Random.Range(maxLeft, maxRight), -7, 0);
        timer = timeToSpawn;
    }
}
