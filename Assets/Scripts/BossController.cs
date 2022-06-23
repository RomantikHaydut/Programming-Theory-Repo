using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject[] cylinders;

    void Start()
    {
        StartCoroutine(BiggerArms());
    }

    
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 90f * Time.deltaTime);
    }

    IEnumerator BiggerArms()
    {
        bool getBig = true;
        while (true)
        {
            if (cylinders[0].transform.localScale.y <= 5.1f && getBig)
            {
                yield return new WaitForFixedUpdate();
                cylinders[0].transform.localScale += new Vector3(0, cylinders[0].transform.localScale.y * 5, 0) * Time.deltaTime / 2;
                cylinders[1].transform.localScale += new Vector3(0, cylinders[1].transform.localScale.y * 5, 0) * Time.deltaTime / 2;
                if (cylinders[0].transform.localScale.y >= 5f)
                {
                    getBig = false;
                }
            }
            else if (cylinders[0].transform.localScale.y >= 1 && !getBig)
            {
                yield return new WaitForFixedUpdate();
                cylinders[0].transform.localScale -= new Vector3(0, cylinders[0].transform.localScale.y * 5, 0) * Time.deltaTime / 2;
                cylinders[1].transform.localScale -= new Vector3(0, cylinders[1].transform.localScale.y * 5, 0) * Time.deltaTime / 2;
                if (cylinders[0].transform.localScale.y <= 1.1f)
                {
                    getBig = true;
                }
            }
        }
        /*while (cylinders[0].transform.localScale.y<=5 && getBig)
        {

            yield return new WaitForFixedUpdate();
            cylinders[0].transform.localScale += new Vector3(0, cylinders[0].transform.localScale.y * 5,0)*Time.deltaTime/2;
            cylinders[1].transform.localScale += new Vector3(0, cylinders[1].transform.localScale.y * 5, 0) * Time.deltaTime/2;

        }
        getBig = false;
        while (cylinders[0].transform.localScale.y >= 1 && !getBig)
        {
            yield return new WaitForFixedUpdate();
            cylinders[0].transform.localScale -= new Vector3(0, cylinders[0].transform.localScale.y * 5, 0) * Time.deltaTime / 2;
            cylinders[1].transform.localScale -= new Vector3(0, cylinders[1].transform.localScale.y * 5, 0) * Time.deltaTime / 2;
        }
        StartCoroutine(BiggerArms());
        */
    }
}
