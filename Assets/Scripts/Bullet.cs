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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
