using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : ProjectileBase
{
    
    void Start()
    {
        name = "Hammer";
        damage = 3f;
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
            Destroy(other.gameObject);
        }
    }
}
