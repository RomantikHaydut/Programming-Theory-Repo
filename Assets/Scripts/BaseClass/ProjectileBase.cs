using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    protected string name;

    protected Vector3 direction;

    protected GameObject player;

    protected float m_damage;
    protected float damage 
    {
        get { return m_damage; }
        set
        {
            if (value>0)
            {
                m_damage = value;
            }
            else
            {
                Debug.LogWarning("Damage Value Can't be less then 0  !!!");
            }
        }
    }

    protected void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }




}
