using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI[] options;


    public void ShowOptions()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void IncreaseBombEffectRadius()
    {
        Bomb.effectRadius *= 2;
    }

    public void SecondHammer()
    {
        FindObjectOfType<CubeController>().secondHammerPowerup = true;
        FindObjectOfType<CubeController>().powerup = true;

    }

    public void FasterHammer()
    {
        Hammer.speed = 200;
    }

    public void Cooldown()
    {
        GameManager.secondChangePlayerTime = 3f;
    }

    public void ThrowMoreBumerang()
    {
        if (SphereController.bumerangCount<128)
        {
            SphereController.bumerangCount *= 2;
        }
    }

    public void PickAllExperience()
    {
        GameObject[] experiences = GameObject.FindGameObjectsWithTag("Experience");
        foreach (GameObject exp in experiences)
        {
            exp.GetComponent<Experience>().shouldFollow = true;
            StartCoroutine(exp.GetComponent<Experience>().FollowingPlayer());
        }
    }
}
