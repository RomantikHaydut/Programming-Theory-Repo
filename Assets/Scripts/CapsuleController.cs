using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CapsuleController : Player
{
    Rigidbody rb;
    private float jumpForce;
    public GameObject bombPrefab;
    private bool bombPowerup;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bombPowerup = true;
        moveSpeed = 1.5f;
        jumpForce = 9f;
        shapaName = "Capsule";
    }

    public override void FireProjectile(GameObject projectile)
    {
        if (bombPowerup)
        {
            projectileSpawnPos = transform.position - transform.forward * 2;
            base.FireProjectile(projectile);
        }
        
    }

    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);
    }

    private void Update()
    {
        FireProjectile(bombPrefab);
    }
}
