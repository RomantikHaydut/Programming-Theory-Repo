using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossController : EnemyController
{
    public GameObject[] cylinders;

    void Start()
    {
        StartCoroutine(BiggerArms());
        EventsInStart();
    }


    
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 90f * Time.deltaTime);
        FollowPlayer();
    }

    IEnumerator BiggerArms()
    {
        bool getBig = true;
        while (true)
        {
            float randomSpeed = Random.Range(1.5f, 3);
            float randomExtendDistance = Random.Range(4, 6);
            if (cylinders[0].transform.localScale.y <= 5.1f && getBig)
            {
                yield return new WaitForFixedUpdate();
                cylinders[0].transform.localScale += new Vector3(0, cylinders[0].transform.localScale.y * randomExtendDistance, 0) * Time.deltaTime / randomSpeed;
                cylinders[1].transform.localScale += new Vector3(0, cylinders[1].transform.localScale.y * randomExtendDistance, 0) * Time.deltaTime / randomSpeed;
                if (cylinders[0].transform.localScale.y >= 5f)
                {
                    getBig = false;
                }
            }
            else if (cylinders[0].transform.localScale.y >= 1 && !getBig)
            {
                yield return new WaitForFixedUpdate();
                cylinders[0].transform.localScale -= new Vector3(0, cylinders[0].transform.localScale.y * randomExtendDistance, 0) * Time.deltaTime / randomSpeed;
                cylinders[1].transform.localScale -= new Vector3(0, cylinders[1].transform.localScale.y * randomExtendDistance, 0) * Time.deltaTime / randomSpeed;
                if (cylinders[0].transform.localScale.y <= 1.1f)
                {
                    getBig = true;
                }
            }
        }
    }
}
