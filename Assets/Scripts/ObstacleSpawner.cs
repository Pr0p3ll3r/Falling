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

    void Start()
    {
        pooler = GetComponent<ObjectPooler>();
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

        if(timeToSpawn > 0.5f) timeToSpawn -= Time.deltaTime * 0.1f;
    }  
    
    void SpawnObstacle()
    {
        GameObject newObstacle = pooler.GetObject();
        newObstacle.transform.position = transform.position + new Vector3(Random.Range(maxLeft, maxRight), -7, 0);
        newObstacle.SetActive(true);
        timer = timeToSpawn;
    }
}
