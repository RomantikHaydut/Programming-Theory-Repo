using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;

    private SpawnManager spawnManager;

    private GameObject experience;

    private CanvasManager canvasManager;

    public static float speed;

    public int health;
    void Start()
    {
        EventsInStart();
    }

    protected void EventsInStart()
    {
        // Here we set spawning enemy health according to level.
        health = 5;
        health = (SpawnManager.level*health)+3;
        player = GameObject.FindGameObjectWithTag("Player");
        if (SpawnManager.level<=10)
        {
            speed = 2;
        }
        else if (SpawnManager.level>10 && SpawnManager.level<=20)
        {
            speed = 3;
        }
        else if (SpawnManager.level>20)
        {
            speed = 4;
        }
        ProtectSpawnNearPlayer();
        experience = gameObject.transform.Find("Experience").gameObject;
        canvasManager = FindObjectOfType<CanvasManager>();
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
            experience.SetActive(true);
            experience.transform.SetParent(null);
            canvasManager.AddScore(5);
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

    private void OnTriggerEnter(Collider other)
    {
        float stopTime = 1.2f;
        Invoke("SpeedProtect", stopTime);
        if (gameObject.GetComponent<BossController>() && other.gameObject.CompareTag("Player"))
        {
            DealDamage(5);
        }
        else if (!gameObject.GetComponent<BossController>() && other.gameObject.CompareTag("Player"))
        {
            DealDamage(1);
            Destroy(gameObject);
        }

    }


    void SpeedProtect()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    protected void DealDamage(int damage)
    {
        Player.playerHealth -= damage;
        canvasManager.Health();
    }

}
