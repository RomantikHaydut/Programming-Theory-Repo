using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : ProjectileBase
{
    public static float effectRadius=3f;
    void Start()
    {
        name = "Bomb";
        damage = 20;
        GetPlayer();
        StartCoroutine(Explosion());
        direction = (transform.position - player.transform.position);
    }


    IEnumerator Explosion()
    {
        
        // Here bomb will move forward.
        while (Vector3.Distance(player.transform.position, transform.position) <= effectRadius)
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
            if (Vector2.Distance(new Vector2(enemy.transform.position.x,enemy.transform.position.z), new Vector2(transform.position.x,transform.position.z)) <= effectRadius*1.2f)
            {
                Destroy(enemy.gameObject);

            }
        }

        Destroy(gameObject);

        yield break;

    }
}
