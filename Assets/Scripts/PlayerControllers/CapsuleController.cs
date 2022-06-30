using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CapsuleController : Player
{
    Rigidbody rb;
    private float jumpForce;
    public GameObject bombPrefab;
    public static float cooldown;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 4f;
        jumpForce = 9f;
        shapaName = "Capsule";
        cooldown = 4f;
    }

    public override void FireProjectile(GameObject projectile,bool takeChild)
    {
        if (Input.GetKeyDown(KeyCode.F) && powerup)
        {
            projectileSpawnPos = transform.position + transform.forward * 2;
            base.FireProjectile(projectile,takeChild);
            Invoke("PowerupCooldown", cooldown);
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

    void PowerupCooldown()
    {
        powerup = true;
    }
}
