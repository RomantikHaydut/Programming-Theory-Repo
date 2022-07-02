using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SphereController : Player
{
    public GameObject bumerangPrefab;
    public static int bumerangCount;
    private bool canPowerup;
    public static float cooldown;


    private void Start()
    {
        bumerangCount = 4;
        moveSpeed = 1.5f;
        powerup = true;
        canPowerup = true;
        cooldown = 4f;
        
    }
    void FixedUpdate()
    {
        Move(transform);

    }

    private void Update()
    {
        if (canPowerup && Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }

    }

    void Fire()
    {
        for (int i = 0; i < bumerangCount; i++)
        {
            
            float angle = i * Mathf.PI * 2 / bumerangCount;
            projectileSpawnPos = transform.position + transform.up / 6 + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle))*2;
            Instantiate(bumerangPrefab, projectileSpawnPos, bumerangPrefab.transform.rotation);
        }
        canPowerup = false;
        Invoke("PowerupOn", cooldown);
    }

    void PowerupOn()
    {
        canPowerup = true;
    }
}
