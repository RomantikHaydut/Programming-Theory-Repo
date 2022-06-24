using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : ProjectileBase
{
    
    void Start()
    {
        name = "Hammer";
        damage = 5f;
        GetPlayer();
    }

    
    void FixedUpdate()
    {
        TurnAroundPlayer();
    }

    void TurnAroundPlayer()
    {
        transform.RotateAround(player.transform.position, Vector3.up,90f*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().health -= (int)damage;
            if (other.gameObject)
            {
                Vector3 forceDirection = (other.gameObject.transform.position - transform.parent.position).normalized;
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceDirection.x,0,forceDirection.z) * 10f, ForceMode.Impulse);
            }

        }
    }
}
