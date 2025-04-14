using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFire : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float laserSpeed = 50f;
    public float lifeTime = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = laser.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * laserSpeed;
        Destroy(laser, lifeTime);
    }
}
