using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumerang : ProjectileBase
{
    private float lifeTime = 9;

    private float speed;
    void Start()
    {
        speed = 3.5f;
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
        if (lifeTime<=9 && lifeTime>=5)
        {
            speed = lifeTime*2 / 2.4f;
            transform.position += direction * Time.deltaTime * speed;
        }
        else if (lifeTime<5)
        {
            GetPlayer();
            if (speed<=9)
            {
                speed = 7 / lifeTime;
            }
            direction = -(player.transform.position - transform.position).normalized;
            transform.position -= direction * Time.deltaTime * speed;
        }
        
        transform.Rotate(transform.up, 90 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !other.gameObject.GetComponent<BossController>())
        {
            other.gameObject.GetComponent<EnemyController>().health -= (int)damage;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
