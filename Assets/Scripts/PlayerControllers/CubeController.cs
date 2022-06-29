using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : Player
{
    Rigidbody rb;
    private float jumpForce;
    public GameObject hammerPrefab;
    public bool secondHammerPowerup;
    private Transform firstHammer;
    private GameObject secondHammer;
    private Vector4 hammerRotation;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 3f;
        jumpForce = 7;
        shapaName = "Cube";
        secondHammerPowerup = false;
    }

    public override void FireProjectile(GameObject projectile,bool takeChild)
    {
        if (powerup && !secondHammerPowerup)
        {
            projectileSpawnPos = transform.position + transform.forward*3.5f;
            base.FireProjectile(projectile,takeChild);
            firstHammer = transform.Find("Hammer(Clone)").gameObject.transform;
            firstHammer.gameObject.name = "Hammer";
        }
        else if (powerup && secondHammerPowerup)
        {
            
            hammerRotation = new Vector4(0, -firstHammer.localRotation.y, 0 , firstHammer.localRotation.w);
            projectileSpawnPos = new Vector3(-firstHammer.position.x, firstHammer.position.y, -firstHammer.position.z);
            base.FireProjectile(projectile, takeChild);
            secondHammer= transform.Find("Hammer(Clone)").gameObject.transform.gameObject;
            secondHammer.transform.eulerAngles = new Vector3(0, firstHammer.transform.eulerAngles.y+180, 0);

        }
    }
    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);
    }

    private void Update()
    {

        FireProjectile(hammerPrefab, true );

        ChangeTimer();
    }
}
