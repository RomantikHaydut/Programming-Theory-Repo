using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : Player
{
    Rigidbody rb;
    private float jumpForce = 7;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Move(Transform trnsfrm)
    {
        moveSpeed = 2f;
        base.Move(trnsfrm);
    }

    void FixedUpdate()
    {
        Move(transform);
        Jump(rb, jumpForce);
    }
}
