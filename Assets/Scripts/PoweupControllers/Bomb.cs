using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ProjectileBase
{
    private float effectRadius;
    void Start()
    {
        name = "Bomb";
        damage = 20;
        effectRadius = 3;
        GetPlayer();
        StartCoroutine(Explosion());
        direction = -(player.transform.position - transform.position);
    }


    IEnumerator Explosion()
    {
        
        // Here bomb will move back.
        while (Vector3.Distance(player.transform.position, transform.position) <= effectRadius*2.5f)
        {
            yield return new WaitForEndOfFrame();
            transform.position += (direction.normalized) * Time.deltaTime* 2.5f;
        }

        yield return new WaitForSeconds(0.2f);

        // Here bomb is getting bigger
        while (transform.localScale.x <= effectRadius)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale += (Vector3.one * Time.deltaTime);
            transform.position += new Vector3(0, 1 * Time.deltaTime, 0);

        }

        yield return new WaitForSeconds(0.2f);

        // Here bomb is explosing ad destroying objects in area
        GameObject[] objectsInArea = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in objectsInArea)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) <= effectRadius*2)
            {
                Destroy(enemy.gameObject);

            }
        }

        Destroy(gameObject);

        yield break;

    }
}
