using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeMover : Mover
{
    public override bool CanLoopBeCoroutine() =>
        (transform.localScale - target).magnitude > _offset;

    public override void PlaceInTarget()
    {
        transform.localScale = target;
        InvokeEndEvent();
    }

    public override void MakeIteration() =>
       transform.localScale = Vector3.MoveTowards(transform.localScale, target,
                                                        _speed * Time.fixedDeltaTime);
}
