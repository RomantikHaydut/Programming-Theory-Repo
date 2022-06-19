using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : Player
{
    
    public override void Move(Transform trnsfrm)
    {
        moveSpeed = 1f;
        base.Move(trnsfrm);
    }
    void FixedUpdate()
    {
        Move(transform);
    }
}
