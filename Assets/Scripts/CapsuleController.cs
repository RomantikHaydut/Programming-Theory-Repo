using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CapsuleController : Player
{
    Rigidbody rb;
    private float jumpForce = 9f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Move(Transform trnsfrm)
    {
        moveSpeed = 1.5f;
        base.Move(trnsfrm);
    }
    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);


    }
}
