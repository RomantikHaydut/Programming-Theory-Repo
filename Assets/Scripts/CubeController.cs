using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : Player
{

    public GameObject hammerPrefab;
    public bool secondHammerPowerup;
    private Transform firstHammer;
    private GameObject secondHammer;

    private void Start()
    {
        moveSpeed = 3f;
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
            projectileSpawnPos = (transform.localPosition - new Vector3(firstHammer.localPosition.x,0,firstHammer.localPosition.z));
            base.FireProjectile(projectile, takeChild);
            secondHammer= transform.Find("Hammer(Clone)").gameObject.transform.gameObject;
            secondHammer.transform.eulerAngles = new Vector3(0, firstHammer.transform.eulerAngles.y+180, 0);

        }
    }
    void FixedUpdate()
    {
        Move(transform);
    }

    private void LateUpdate()
    {
        FireProjectile(hammerPrefab, true );
    }
}
