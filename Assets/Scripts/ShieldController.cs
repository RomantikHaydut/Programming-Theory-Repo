using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        GetPlayer();
        transform.position = player.transform.position;
        Destroy(gameObject, 25f);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(enemies[i].transform.position, transform.position);
            if (distance <= 3f)
            {
                Rigidbody enemyRb = enemies[i].gameObject.GetComponent<Rigidbody>();
                Vector3 forceDirection = (enemies[i].gameObject.transform.position - transform.position).normalized;
                enemyRb.AddForce(new Vector3(forceDirection.x, 0, forceDirection.z) * 15f, ForceMode.Impulse);
            }
        }   
    }

    
    void FixedUpdate()
    {
        FollowPlayer();
    }

    void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FollowPlayer()
    {
        GetPlayer();
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (other.gameObject.transform.position - transform.position).normalized;
            enemyRb.AddForce(new Vector3(forceDirection.x,0,forceDirection.z)*10f,ForceMode.Impulse);
        }
    }

    private void OnDestroy()
    {
        Player.shieldOn = false;
    }
}
