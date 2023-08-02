using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardRotater : MonoBehaviour
{
    [SerializeField] private float _rotationCoeff = -1.2f;
    [SerializeField] private Mover mover;

    private Coroutine coroutine;

    private void Awake()
    {
        GetComponent<CursorFollower>().StartFollow += () => coroutine = StartCoroutine(Rotating());
        mover.GotToPlace += () => StopCoroutine(coroutine);
    }

    private IEnumerator Rotating()
    {
        while (true)
        {
            transform.eulerAngles = 
            transform.eulerAngles.WithZ(transform.position.x * _rotationCoeff);
            yield return new WaitForFixedUpdate();
        }
    }
}