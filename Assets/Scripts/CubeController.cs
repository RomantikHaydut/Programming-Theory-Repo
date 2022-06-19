using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Player
{
 
    public override void Move(Transform trnsfrm)
    {
        moveSpeed = 2f;
        base.Move(trnsfrm);
    }

    void FixedUpdate()
    {
        Move(transform);
    }
}
