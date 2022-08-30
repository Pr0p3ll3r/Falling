using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
