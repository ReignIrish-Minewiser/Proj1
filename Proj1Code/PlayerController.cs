using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 2f;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        transform.Rotate(0, mouseX, 0); // Horizontal rotation

        if(Input.GetMouseButtonDown(0)){
            FireBullet();
        }

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); // Vertical rotation
    }
    void FireBullet()
    {
        if (firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}