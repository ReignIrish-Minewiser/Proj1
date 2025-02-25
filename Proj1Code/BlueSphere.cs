using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphere : MonoBehaviour
{
    public float lifespan = 5f;

    void Start()
    {
        Destroy(gameObject, lifespan);  // Destroy after 5 seconds
    }
}
