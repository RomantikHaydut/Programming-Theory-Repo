using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameOverPanel;
    public GameObject[] options;
    public GameManager gameManager;
    public GameObject shield;
    public bool shieldPowerup = false;
    public static int destroyedOptions = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverText;
    public int score;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        score = 0;
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
        if (destroyedOptions < 6)
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
        if (gameManager.activePlayer.GetComponent<SphereController>())
        {
            gameManager.SelectCapsule();
            Bomb.effectRadius *= 2;
            gameManager.SelectSphere();
        }
        else if (gameManager.activePlayer.GetComponent<CubeController>())
        {
            gameManager.SelectCapsule();
            Bomb.effectRadius *= 2;
            gameManager.SelectCube();
        }
        else
        {
            Bomb.effectRadius *= 2;
        }

        if (Bomb.effectRadius >= 6)
        {
            destroyedOptions++;
            options[3].SetActive(false);
        }
        CloseOptions();
    }

    public void SecondHammer()
    {
        if (gameManager.activePlayer.GetComponent<SphereController>())
        {
            gameManager.SelectCube();
            FindObjectOfType<CubeController>().secondHammerPowerup = true;
            FindObjectOfType<CubeController>().powerup = true;
            gameManager.SelectSphere();
        }
        else if (gameManager.activePlayer.GetComponent<CapsuleController>())
        {
            gameManager.SelectCube();
            FindObjectOfType<CubeController>().secondHammerPowerup = true;
            FindObjectOfType<CubeController>().powerup = true;
            gameManager.SelectCapsule();
        }
        else
        {
            FindObjectOfType<CubeController>().secondHammerPowerup = true;
            FindObjectOfType<CubeController>().powerup = true;
        }
        FindObjectOfType<CameraController>().GetPlayer();
        options[1].gameObject.SetActive(true);
        options[2].gameObject.SetActive(false);
        destroyedOptions++;
        CloseOptions();
    }

    public void FasterHammer()
    {

        if (gameManager.activePlayer.GetComponent<SphereController>())
        {
            gameManager.SelectCube();
            Hammer.speed = 200;
            gameManager.SelectSphere();
        }
        else if (gameManager.activePlayer.GetComponent<CapsuleController>())
        {
            gameManager.SelectCube();
            Hammer.speed = 200;
            gameManager.SelectCapsule();
        }
        else
        {
            Hammer.speed = 200;
        }
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
        if (gameManager.activePlayer.GetComponent<CubeController>())
        {
            gameManager.SelectSphere();
            SphereController.bumerangCount *= 2;
            gameManager.SelectCube();
        }
        else if (gameManager.activePlayer.GetComponent<CapsuleController>())
        {
            gameManager.SelectSphere();
            SphereController.bumerangCount *= 2;
            gameManager.SelectCapsule();
        }
        else
        {
            SphereController.bumerangCount *= 2;
        }
        if (SphereController.bumerangCount >= 32)
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

    public void AddScore(int Score)
    {
        score += Score;
        scoreText.text = "Score : " + score;
    }

    public void Health()
    {
        healthText.text = "Health : %" + Player.playerHealth;
        if (Player.playerHealth<=0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            gameOverText.text = "Game Over! \n" + "Score : " + score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
