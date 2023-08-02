using System;
using UnityEngine;

public interface IMover
{
    public event Action StartMove;
    public event Action GotToPlace;
    public abstract void Move(Vector3 target);
    public void GetInPlace();
}
