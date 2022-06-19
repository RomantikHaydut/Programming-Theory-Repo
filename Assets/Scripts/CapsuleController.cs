using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : Player
{
    public override void Move(Transform trnsfrm)
    {
        moveSpeed = 1.5f;
        base.Move(trnsfrm);
    }
    void FixedUpdate()
    {
        Move(transform);
    }
}
