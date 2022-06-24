using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;

    private SpawnManager spawnManager;

    protected float speed;

    public int health;
    void Start()
    {
        EventsInStart();
    }

    protected void EventsInStart()
    {
        // Here we set spawning enemy health according to level.
        if (SpawnManager.level <= 5)
        {
            health = 10;

        }
        else if (SpawnManager.level > 5 && SpawnManager.level < 10)
        {
            health = 20;
        }
        else if (SpawnManager.level >= 10)
        {
            health = 200;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 2;
        ProtectSpawnNearPlayer();
        Debug.LogError("Enemy Health : " + health);
    }
    
    void FixedUpdate()
    {
        FollowPlayer();
    }

    protected void FollowPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += new Vector3(direction.x,0,direction.z)*Time.deltaTime*speed;
        if (health<=0)
        {
            SpawnManager.destroyedEnemyCount++;
            Destroy(gameObject);
        }
    }

    protected void ProtectSpawnNearPlayer()
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
