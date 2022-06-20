using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SphereController : Player
{
    private float jumpForce = 11.5f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Move(Transform trnsfrm)
    {
        moveSpeed = 1f;
        base.Move(trnsfrm);
    }
    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);


    }
}
