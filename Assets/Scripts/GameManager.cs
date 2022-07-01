using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    private CameraController cam;

    public static int level;

    public static float secondChangePlayerTime;

    private Vector3 activePosition;

    private GameObject activePlayer;
    void Awake()
    {
        level = 1;
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }
        players[0].SetActive(true);
    }
    private void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        cam.GetPlayer();
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        ChangePlayer();
    }

    void ChangePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Player.changePlayerCooldown <= secondChangePlayerTime && players[0].activeInHierarchy == false)
        {
            SelectCube();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && Player.changePlayerCooldown <= secondChangePlayerTime && players[1].activeInHierarchy == false)
        {
            SelectSphere();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && Player.changePlayerCooldown <= secondChangePlayerTime && players[2].activeInHierarchy == false)
        {
            SelectCapsule();
        }
    }

    public void SelectCube()
    {
        GetPlayer();
        players[0].SetActive(true);
        players[1].SetActive(false);
        players[2].SetActive(false);
        GetPosition(players[0]);
        cam.GetPlayer();
        Player.changePlayerCooldown = 5f;
    }

    public void SelectSphere()
    {
        GetPlayer();
        players[0].SetActive(false);
        players[1].SetActive(true);
        players[2].SetActive(false);
        GetPosition(players[1]);
        cam.GetPlayer();
        Player.changePlayerCooldown = 5f;
    }

    public void SelectCapsule()
    {
        GetPlayer();
        players[0].SetActive(false);
        players[1].SetActive(false);
        players[2].SetActive(true);
        GetPosition(players[2]);
        cam.GetPlayer();
        Player.changePlayerCooldown = 5f;
    }

    void GetPlayer()
    {
        activePlayer = GameObject.FindGameObjectWithTag("Player");
    }
    Vector3 GetPosition(GameObject nextPlayer)
    {
        activePosition = activePlayer.transform.position;
        nextPlayer.transform.position = activePosition;
        return activePosition;
    }
}
