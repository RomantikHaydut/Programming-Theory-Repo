using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float m_moveSpeed;

    public float moveSpeed
    {
        get { return m_moveSpeed; }

        set
        {
            // Here we protect base speed.
            if (value<=0)
            {
                Debug.LogError("Move Speed Less Then 0 Ther is no Movement.");
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

    public void Jump(GameObject player, Rigidbody playerRb,float jumpForce)
    {
        playerRb.AddRelativeForce(player.transform.up * jumpForce,ForceMode.Impulse);
    }

    public void FireProjectile(GameObject projectile,Vector3 spawnPos)
    {
        Instantiate(projectile, spawnPos, projectile.transform.rotation);
    }

}
