using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject hammerPrefab;

    public GameObject ringPrefab;

    public GameObject bombPrefab;


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

    public virtual void Move(Transform trnsfrm)
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

    public virtual void FireProjectile(GameObject projectile,Vector3 spawnPos)
    {
        Instantiate(projectile, spawnPos, projectile.transform.rotation);
    }


}
