using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour, IPooledObject
{
    public static event Action OnGameOver;

    [SerializeField] private float moveSpeed;

    public ObjectPooler Pool { get; set; }

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        if (transform.position.y > 7f)
            Pool.ReturnToPool(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene(0);
        OnGameOver?.Invoke();
    }
}
