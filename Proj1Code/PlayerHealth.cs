using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 25;
    public GameObject player;

    public Transform BlueSphere;

    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Bullet"))
        {
            health = health - 1;
            Destroy(collision.gameObject);
            Debug.Log("Player Health is now " + health);
        }

        if (collision.gameObject.CompareTag("BlueSphere"))
        {
            health += 2;
            Destroy(collision.gameObject);
            Debug.Log("Player Health is now " + health);
        }

        if (health <= 0)
        {
            Debug.Log("Player has died");
            player.GetComponent<PlayerController>().enabled = false;
        }
    }
}
