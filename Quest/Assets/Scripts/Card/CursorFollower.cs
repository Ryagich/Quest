using System;
using System.Collections;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    public event Action StartFollow;
    public event Action EndFollow;
    public bool IsFollow { get; private set; }

    [SerializeField, Min(.0f)] private float _size = 32f;

    private Coroutine coroutine;
    private Vector3 offset;
    private float defY;

    private void Awake()
    {
        defY = transform.position.y;

        InputHandler.LeftMouseDown += TryFollow;
        InputHandler.LeftMouseUp += StopFollow;
    }

    private void OnDestroy()
    {
        InputHandler.LeftMouseDown -= TryFollow;
        InputHandler.LeftMouseUp -= StopFollow;
    }

    private void TryFollow()
    {
        var point = InputHandler.MouseWorldPos(110);
        var pos = transform.position;

        if (-_size + pos.x < point.x && point.x < _size + pos.x
         && -_size + pos.y < point.y && point.y < _size + pos.y)
        {
            offset = new(-point.x, -point.y + defY);
            IsFollow = true;
            coroutine = StartCoroutine(Follow());

            StartFollow?.Invoke();
        }
    }

    private IEnumerator Follow()
    {
        while (true)
        {
            var newPos = offset + InputHandler.MouseWorldPos(110);
            transform.position = new(newPos.x, newPos.y, transform.position.z);
            yield return new WaitForFixedUpdate();
        }
    }

    public void StopFollow()
    {
        if (IsFollow)
        {
            StopCoroutine(coroutine);
            IsFollow = false;

            EndFollow?.Invoke();
        }
    }
}