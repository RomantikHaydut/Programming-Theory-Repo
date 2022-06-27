using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CapsuleController : Player
{
    Rigidbody rb;
    private float jumpForce;
    public GameObject bombPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 4f;
        jumpForce = 9f;
        shapaName = "Capsule";
    }

    public override void FireProjectile(GameObject projectile,bool takeChild)
    {
        if (Input.GetMouseButtonDown(0) && powerup)
        {
            projectileSpawnPos = transform.position + transform.forward * 2;
            base.FireProjectile(projectile,takeChild);
        }
        
    }

    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);
    }

    private void Update()
    {
        FireProjectile(bombPrefab,false);
        ChangeTimer();
    }
}
