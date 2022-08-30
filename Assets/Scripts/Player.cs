using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool gyroEnabled;
    private float dirX;
    [SerializeField] private float moveSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(SystemInfo.supportsGyroscope)
        {
            dirX = Input.acceleration.x * moveSpeed;
        }
        else
        {
            dirX = Input.GetAxis("Horizontal") * moveSpeed;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.7f, 2.7f), transform.position.y, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, 0f, 0f);
    }
}
