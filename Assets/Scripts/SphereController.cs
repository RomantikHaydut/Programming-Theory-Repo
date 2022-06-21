using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SphereController : Player
{
    private float jumpForce;
    Rigidbody rb;
    public GameObject bumerangPrefab;
    private bool bumarangPowerup;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bumarangPowerup = true;
        moveSpeed = 1f;
        jumpForce = 11.5f;
        shapaName = "Sphere";

    }
    public override void FireProjectile(GameObject projectile)
    {
        if (bumarangPowerup)
        {
            for (int i = 0; i < 4; i++)
            {
                projectileSpawnPos = transform.position + transform.up/3 + new Vector3(Mathf.Sin(i * 90 * Mathf.Deg2Rad), 0, Mathf.Cos(i * 90 * Mathf.Deg2Rad)) * 2;
                base.FireProjectile(projectile);

            }
        }
    }
    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);

    }

    private void Update()
    {
        FireProjectile(bumerangPrefab);
    }
}
