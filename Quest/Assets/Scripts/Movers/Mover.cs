using System;
using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour, IMover
{
    public event Action StartMove;
    public event Action GotToPlace;
    [HideInInspector] public bool IsMoving => coroutine != null;

    [SerializeField, Min(.0f)] protected float _speed = 5.0f;
    [SerializeField, Min(.0f)] protected float _offset = .1f;

    protected Vector3 target;
    private Coroutine coroutine;

    public void GetInPlace()
    {
        if (!IsMoving)
            return;
        StopCoroutine(coroutine);
        PlaceInTarget();
    }

    public void Move(Vector3 target)
    {
        this.target = target;
        coroutine = StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        InvokeStartEvent();
        while (CanLoopBeCoroutine())
        {
            MakeIteration();
            yield return new WaitForFixedUpdate();
        }
        PlaceInTarget();
    }
    public void InvokeStartEvent() => StartMove?.Invoke();
    public void InvokeEndEvent() => GotToPlace?.Invoke();
    public virtual bool CanLoopBeCoroutine() =>
        (transform.position - target).magnitude > _offset;

    public virtual void PlaceInTarget()
    {
        transform.position = target;
        InvokeEndEvent();
    }

    public virtual void MakeIteration() =>
        transform.position = Vector3.MoveTowards(transform.position, target,
                                             _speed * Time.fixedDeltaTime);
}

