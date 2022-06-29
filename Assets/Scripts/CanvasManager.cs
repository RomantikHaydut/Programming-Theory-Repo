using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI[] options;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ShowOptions();

        }
    }


    void ShowOptions()
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
}
