using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;

    private float speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 2;
        ProtectSpawnNearPlayer();
    }

    
    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction*Time.deltaTime*speed;
    }

    void ProtectSpawnNearPlayer()
    {
        //Here in spawning if enemy spawns near the player we get away it from player..
        float spawnDistance= Vector3.Distance(player.transform.position, transform.position);
        if (spawnDistance<=22f)
        {
            Vector3 direction = (transform.position - player.transform.position).normalized;
            transform.position += new Vector3(direction.x,0,direction.z) * 40f;

        }
    }



}
