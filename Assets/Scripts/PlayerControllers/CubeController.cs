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
    private float hammerTimer;
    public static float hammerDisappearTime;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = 3f;
        jumpForce = 7;
        shapaName = "Cube";
        secondHammerPowerup = false;
        hammerTimer = 4f;
        hammerDisappearTime = -3f;
    }

    public override void FireProjectile(GameObject projectile,bool takeChild)
    {
        if (powerup && !secondHammerPowerup)
        {
            projectileSpawnPos = transform.position + transform.forward*3.5f;
            base.FireProjectile(projectile,takeChild);
            firstHammer = transform.Find("Hammer(Clone)").gameObject.transform;
            firstHammer.gameObject.name = "Hammer";
            StartCoroutine(AppearAndDisappearFirst());
        }
        else if (powerup && secondHammerPowerup)
        {
            hammerTimer = 5f;
            hammerRotation = new Vector4(0, -firstHammer.localRotation.y, 0 , firstHammer.localRotation.w);
            projectileSpawnPos = new Vector3(-firstHammer.position.x, firstHammer.position.y, -firstHammer.position.z);
            base.FireProjectile(projectile, takeChild);
            secondHammer= transform.Find("Hammer(Clone)").gameObject.transform.gameObject;
            secondHammer.transform.eulerAngles = new Vector3(0, firstHammer.transform.eulerAngles.y+180, 0);
            StartCoroutine(AppearAndDisappearSecond());

        }
    }
    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);
    }

    private void Update()
    {
        hammerTimer -= Time.deltaTime;
        if (hammerTimer<=hammerDisappearTime)
        {
            hammerTimer = 5f;
        }
        FireProjectile(hammerPrefab, true );

        ChangeTimer();
    }
    IEnumerator AppearAndDisappearFirst()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (hammerTimer >= 0)
            {
                firstHammer.gameObject.SetActive(true);
            }
            if (hammerTimer < 0)
            {
                firstHammer.gameObject.SetActive(false);
            }

        }

    }
    IEnumerator AppearAndDisappearSecond()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (hammerTimer >= 0)
            {
                secondHammer.SetActive(true);
            }
            if (hammerTimer < 0)
            {
                secondHammer.SetActive(false);
            }
        }
        
    }
}
