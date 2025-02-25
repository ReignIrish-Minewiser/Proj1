using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    // This method is called when the bullet collides with another object
    void OnCollisionEnter(Collision collision)
    {
        // If the bullet hits an enemy, deal damage to the enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Call TakeDamage method on the enemy
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }

        // Destroy the bullet after it collides
        Destroy(gameObject);
    }
}
