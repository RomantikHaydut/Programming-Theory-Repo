using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    protected private string shapaName;

    public static int playerHealth = 100;

    public static int playerExperience;
    
    protected   Vector3 projectileSpawnPos;

    private float m_moveSpeed; // base speed

    public float moveSpeed
    {
        get { return m_moveSpeed; }

        set
        {
            // Here we protect base speed.
            if (value<=0)
            {
                Debug.LogError("Move Speed is Less Then 0 There is no Movement.");
            }
            else
            {
                m_moveSpeed = value;
            }
        }

    }


    public  void Move(Transform trnsfrm)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        trnsfrm.position += new Vector3(horizontalInput * Time.deltaTime * m_moveSpeed, 0, verticalInput * Time.deltaTime * m_moveSpeed);
    }

    public void Jump(Rigidbody playerRb,float jumpForce)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = new Vector3(0, jumpForce, 0);
        }

    }

    public virtual void FireProjectile(GameObject projectile,bool makeChild)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (makeChild)
            {
                Instantiate(projectile, projectileSpawnPos, projectile.transform.rotation,transform);

            }
            else
            {
                Instantiate(projectile, projectileSpawnPos, projectile.transform.rotation);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Experience"))
        {
            playerExperience++;
            if (playerExperience%10==0)
            {
                // Here we show buff options... 
                
            }
            Destroy(other.gameObject);
        }
    }


}
