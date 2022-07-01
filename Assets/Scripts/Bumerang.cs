using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumerang : ProjectileBase
{
    private float lifeTime = 10;
    void Start()
    {
        name = "Bumerang";
        damage = 3+(SpawnManager.level);
        GetPlayer();
        direction = -(player.transform.position - transform.position).normalized;
    }

    
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime<=10 && lifeTime>=5)
        {
            transform.position += direction * Time.deltaTime * 3.5f;
        }
        else if (lifeTime<5)
        {
            GetPlayer();
            direction = -(player.transform.position - transform.position).normalized;
            transform.position -= direction * Time.deltaTime * 3.5f;
        }
        
        transform.Rotate(transform.up, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().health -= (int)damage;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
