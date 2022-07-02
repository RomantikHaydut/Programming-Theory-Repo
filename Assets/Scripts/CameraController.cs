using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    Vector3 offSet;
    
    void Start()
    {
        GetPlayer();
        transform.LookAt(player.transform);
    }

    
    void LateUpdate()
    {
        FollowPlayer();
    }

    public void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(0,17,-15);
        offSet = transform.position - player.transform.position;
    }

    void FollowPlayer()
    {
        transform.position = player.transform.position + offSet;

    }

}
