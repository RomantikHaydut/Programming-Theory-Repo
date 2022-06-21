using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ProjectileBase
{
    private float effectRadius;
    void Start()
    {
        name = "Bomb";
        damage = 10;
        effectRadius = 5;
        GetPlayer();
        StartCoroutine(Explosion());
        direction = -(player.transform.position - transform.position);
    }


    IEnumerator Explosion()
    {
        

        while (Vector3.Distance(player.transform.position, transform.position) <= 5.1f)
        {
            yield return new WaitForEndOfFrame();
            transform.position += (direction.normalized) * Time.deltaTime* 2.5f;
        }

        yield return new WaitForSeconds(0.2f);

        while (transform.localScale.x <= effectRadius)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale += (Vector3.one * Time.deltaTime);
            transform.position += new Vector3(0, 1 * Time.deltaTime, 0);

        }

        yield return new WaitForSeconds(0.2f);

        GameObject[] objectsInArea = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in objectsInArea)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) <= effectRadius)
            {
                Destroy(enemy.gameObject);

            }
        }

        Destroy(gameObject);

        yield break;

    }
}
