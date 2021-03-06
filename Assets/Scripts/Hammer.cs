using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : ProjectileBase
{
    public static float speed=120;
    void Start()
    {
        name = "Hammer";
        damage = 5+(SpawnManager.level*2);
        GetPlayer();
    }


    void FixedUpdate()
    {
        TurnAroundPlayer();
    }

    void TurnAroundPlayer()
    {
        transform.RotateAround(player.transform.position, Vector3.up, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().health -= (int)damage;
            if (other.GetComponent<Rigidbody>() && other.gameObject)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb.mass <= 1.5f && SpawnManager.level<=20)
                {
                    Vector3 forceDirection = (other.gameObject.transform.position - transform.parent.position).normalized;
                    other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceDirection.x, 0, forceDirection.z) * 10f, ForceMode.Impulse);
                }
            }
        }

    }


}
