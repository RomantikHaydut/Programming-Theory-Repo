using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CapsuleController : Player
{
    public GameObject bombPrefab;
    public static float cooldown;

    private void Start()
    {
        moveSpeed = 4f;
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
    }

    private void Update()
    {
        FireProjectile(bombPrefab,false);
    }

    void PowerupCooldown()
    {
        powerup = true;
    }
}
