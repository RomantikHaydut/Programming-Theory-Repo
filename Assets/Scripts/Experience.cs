using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private GameObject player;

    public bool shouldFollow;
    
    void FixedUpdate()
    {
        FollowPlayer();
    }


    void FollowPlayer()
    {
        if (gameObject.activeInHierarchy==true && !shouldFollow)
        {
            
            player = GameObject.FindGameObjectWithTag("Player").gameObject;
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 3f * transform.localScale.x)
            {
                shouldFollow = true;
                StartCoroutine(FollowingPlayer());

            }
            
        }
        
    }

    public IEnumerator FollowingPlayer()
    {
        while (shouldFollow)
        {
            yield return new WaitForFixedUpdate();
            player = GameObject.FindGameObjectWithTag("Player").gameObject;
            Vector3 direction = (player.transform.position - transform.position);
            transform.position += direction * Time.deltaTime * 2f;

        }
    }
}
