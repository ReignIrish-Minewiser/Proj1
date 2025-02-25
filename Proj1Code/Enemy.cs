using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public float speed = 3f; // Speed of the enemy
    public float stopDistance = 5f; // Distance at which the enemy stops approaching
    public GameObject bulletPrefab;
    public GameObject blueSpherePrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float lastFireTime;
    
    public Transform player;

    void Start()
    {
        health = 1;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardPlayer();
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
        }

        if (Time.time - lastFireTime >= fireRate)
        {
            FireBullet();
            lastFireTime = Time.time;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Death();
        }
            
    }

    void MoveTowardPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        // If the distance is greater than the stop distance, move towards the player
        if (distance > stopDistance)
        {
            // Calculate direction to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void FireBullet()
    {
        if (firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void Death(){
        Instantiate(blueSpherePrefab, transform.position, transform.rotation);
    }
}
