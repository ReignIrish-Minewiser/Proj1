using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // How fast the bullet moves

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the bullet
        rb = GetComponent<Rigidbody>();

        // Set the velocity to move the bullet forward
        if (rb != null)
        {
            rb.velocity = transform.forward * speed; // Apply forward velocity to the bullet
        }
        else
        {
            Debug.LogWarning("No Rigidbody attached to the bullet!");
        }
    }
}
