using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float timeToLive = 5f;
    private float timeSinceSpawned = 0f;

    void Awake()
    {

    }

    void Update()
    {
        transform.position += moveSpeed * transform.up * Time.deltaTime;
        timeSinceSpawned += Time.deltaTime;

        if (timeSinceSpawned > timeToLive)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet on collision
        //Destroy(gameObject);
    }
}
