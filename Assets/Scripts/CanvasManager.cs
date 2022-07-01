using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] options;
    public GameManager gameManager;
    public GameObject shield;
    public bool shieldPowerup = false;
    public static int destroyedOptions = 0;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && shieldPowerup)
        {
            shield.SetActive(true);
            shieldPowerup = false;
        }
    }
    public void ShowOptions()
    {
        if (destroyedOptions<6)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }
        
    }

    private void CloseOptions()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void IncreaseBombEffectRadius()
    {
        gameManager.SelectCapsule();
        Bomb.effectRadius *= 2;
        if (Bomb.effectRadius>=12)
        {
            destroyedOptions++;
            options[3].SetActive(false);
        }
        CloseOptions();
    }

    public void SecondHammer()
    {
        gameManager.SelectCube();
        FindObjectOfType<CubeController>().secondHammerPowerup = true;
        FindObjectOfType<CubeController>().powerup = true;
        FindObjectOfType<CameraController>().GetPlayer();
        options[1].gameObject.SetActive(true);
        options[2].gameObject.SetActive(false);
        destroyedOptions++;
        CloseOptions();
    }

    public void FasterHammer()
    {
        Hammer.speed = 200;
        options[1].gameObject.SetActive(false);
        destroyedOptions++;
        CloseOptions();

    }

    public void ShieldAbility()
    {
        options[0].gameObject.SetActive(false);
        destroyedOptions++;
        shieldPowerup = true;
        CloseOptions();

    }

    public void AbilityCooldown()
    {
        if (gameManager.activePlayer.GetComponent<CubeController>())
        {
            gameManager.SelectSphere();
            SphereController.cooldown = 1.5f;
            gameManager.SelectCapsule();
            CapsuleController.cooldown = 1.5f;
            gameManager.SelectCube();
        }
        else if (gameManager.activePlayer.GetComponent<SphereController>())
        {
            SphereController.cooldown = 1.5f;
            gameManager.SelectCapsule();
            CapsuleController.cooldown = 1.5f;
            gameManager.SelectSphere();
        }
        else if (gameManager.activePlayer.GetComponent<CapsuleController>())
        {
            gameManager.SelectSphere();
            SphereController.cooldown = 1.5f;
            gameManager.SelectCapsule();
            CapsuleController.cooldown = 1.5f; 
        }

        destroyedOptions++;
        CloseOptions();
        options[6].gameObject.SetActive(false);
    }

    public void ThrowMoreBumerang()
    {
        gameManager.SelectSphere();
        if (SphereController.bumerangCount < 32)
        {
            SphereController.bumerangCount *= 2;
        }
        else if (SphereController.bumerangCount >= 32)
        {
            options[4].SetActive(false);
            destroyedOptions++;
        }
        CloseOptions();

    }

    public void PickAllExperience()
    {
        GameObject[] experiences = GameObject.FindGameObjectsWithTag("Experience");
        foreach (GameObject exp in experiences)
        {
            exp.GetComponent<Experience>().shouldFollow = true;
            StartCoroutine(exp.GetComponent<Experience>().FollowingPlayer());

        }
        CloseOptions();

        return;
    }
}
