using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;

    private CameraController cam;

    public static int level;

    private Vector3 activePosition;

    public GameObject activePlayer;
    void Awake()
    {
        level = 1;
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }
        players[0].SetActive(true);
        GetPlayer();


    }
    private void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        Time.timeScale = 1;

    }

    void FixedUpdate()
    {
        ChangePlayer();
    }

    void ChangePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && players[0].activeInHierarchy == false)
        {
            SelectCube();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && players[1].activeInHierarchy == false)
        {
            SelectSphere();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && players[2].activeInHierarchy == false)
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
    }

    public void SelectSphere()
    {
        GetPlayer();
        players[0].SetActive(false);
        players[1].SetActive(true);
        players[2].SetActive(false);
        GetPosition(players[1]);
        cam.GetPlayer();
    }

    public void SelectCapsule()
    {
        GetPlayer();
        players[0].SetActive(false);
        players[1].SetActive(false);
        players[2].SetActive(true);
        GetPosition(players[2]);
        cam.GetPlayer();
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
