using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumerang : ProjectileBase
{
    
    void Start()
    {
        name = "Bumerang";
        damage = 5f;
        GetPlayer();
        direction = -(player.transform.position - transform.position).normalized;
    }

    
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.position += direction * Time.deltaTime * 2;
        transform.Rotate(transform.up, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
