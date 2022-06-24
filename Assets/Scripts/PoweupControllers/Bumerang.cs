using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumerang : ProjectileBase
{
    
    void Start()
    {
        name = "Bumerang";
        damage = 2.5f;
        GetPlayer();
        direction = -(player.transform.position - transform.position).normalized;
        Destroy(gameObject, 15f);
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().health -= (int)damage;
            Destroy(gameObject);
        }
    }

}
