using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private GameObject player;

    private bool shouldFollow;
    
    void FixedUpdate()
    {
        FollowPlayer();
    }


    void FollowPlayer()
    {
        if (gameObject.activeInHierarchy==true)
        {
            
            player = GameObject.FindGameObjectWithTag("Player").gameObject;
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance<=3f)
            {
                shouldFollow = true;

            }
            if (shouldFollow)
            {
                Vector3 direction = (player.transform.position - transform.position);
                transform.position += direction * Time.deltaTime * 2f;
            }
            
        }
        
    }
}
