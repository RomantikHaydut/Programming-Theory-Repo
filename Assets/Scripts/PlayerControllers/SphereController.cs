using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SphereController : Player
{
    private float jumpForce;
    Rigidbody rb;
    public GameObject bumerangPrefab;
    private int bumerangCount;
    private bool canPowerup;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 1.5f;
        jumpForce = 11.5f;
        shapaName = "Sphere";
        bumerangCount = 4;
        powerup = true;
        canPowerup = true;
    }
    /*public override void FireProjectile(GameObject projectile, bool takeChild)
    {
        for (int i = 0; i <= bumerangCount; i++)
        {
            projectileSpawnPos = transform.position + transform.up / 4 + new Vector3(Mathf.Sin(i * 90 * Mathf.Deg2Rad), 0, Mathf.Cos(i * 90 * Mathf.Deg2Rad)) * 2;
            base.FireProjectile(projectile, takeChild);
            powerup = true;
            canPowerup = true;
        }

    }*/
    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);

    }

    private void Update()
    {
        if (canPowerup && Input.GetMouseButton(0))
        {
            Fire();
        }
        ChangeTimer();

    }

    void Fire()
    {
        for (int i = 0; i <= bumerangCount; i++)
        {
            projectileSpawnPos = transform.position + transform.up / 6 + new Vector3(Mathf.Sin(i * 90 * Mathf.Deg2Rad), 0, Mathf.Cos(i * 90 * Mathf.Deg2Rad)) * 2;
            Instantiate(bumerangPrefab, projectileSpawnPos, bumerangPrefab.transform.rotation);
        }
        canPowerup = false;
    }
}
