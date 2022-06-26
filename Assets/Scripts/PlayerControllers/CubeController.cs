using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : Player
{
    Rigidbody rb;
    private float jumpForce;
    public GameObject hammerPrefab;

    private bool hammerPowerup;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hammerPowerup = true;
        moveSpeed = 2f;
        jumpForce = 7;
        shapaName = "Cube";


    }

    public override void FireProjectile(GameObject projectile,bool takeChild)
    {
        if (hammerPowerup)
        {
            projectileSpawnPos = transform.position + transform.forward*3.5f;
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
        FireProjectile(hammerPrefab,true);
        ChangeTimer();
    }
}
