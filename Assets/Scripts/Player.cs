using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static int playerHealth = 100;

    public static int playerExperience = 0;

    public bool powerup = true;

    public static bool shieldOn;

    protected int powerupCount;

    protected Vector3 projectileSpawnPos;

    public float m_moveSpeed; // base speed

    public float moveSpeed
    {
        get { return m_moveSpeed; }

        set
        {
            // Here we protect base speed.
            if (value <= 0)
            {
                Debug.LogError("Move Speed is Less Then 0 There is no Movement.");
            }
            else
            {
                m_moveSpeed = value;
            }
        }

    }
    private void Start()
    {
        InvokeRepeating("SpeedProtect", 1f, 1f);
    }

    public void Move(Transform trnsfrm)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        trnsfrm.position += new Vector3(horizontalInput * Time.deltaTime * m_moveSpeed, 0, verticalInput * Time.deltaTime * m_moveSpeed);
    }
    public virtual void FireProjectile(GameObject projectile, bool makeChild)
    {
        if (powerup)
        {
            if (makeChild)
            {
                Instantiate(projectile, projectileSpawnPos, projectile.transform.rotation, transform);
            }
            else
            {
                Instantiate(projectile, projectileSpawnPos, projectile.transform.rotation);
            }
            powerup = false;
        }

    }

    protected void SpeedProtect()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.x>=0.1f)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Experience"))
        {
            playerExperience++;
            if (playerExperience % 20 == 0)
            {
                // Here we show buff options... 
                SpawnManager.level++;
                FindObjectOfType<CanvasManager>().AddScore(5);
                FindObjectOfType<CanvasManager>().ShowOptions();
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("DeadZone"))
        {
            FindObjectOfType<CanvasManager>().GameOver();
        }
    }




}
