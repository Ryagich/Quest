using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionDialogueAlpha : MonoBehaviour
{
    [SerializeField, Range(.0f, 1f)] private float _Coeff = .1f;
    [SerializeField, Range(.0f, 1f)] private float _maxVisibility = .8f;
    [SerializeField] private Mover mover;

    private TMP_Text text;
    private SpriteRenderer textBack;
    private Coroutine coroutine;

    private void Awake()
    {
        var card = GetComponent<SimpleCard>();
        text = card.Action;
        textBack = card.ActionBackground;

        textBack.color = textBack.color.WithA(0);
        text.color = text.color.WithA(0);

        mover.GotToPlace += StopWatch;
        GetComponent<CursorFollower>().StartFollow += () => coroutine = StartCoroutine(Watch());
        GetComponent<FollowReseter>().Reseted += StopWatch;
    }

    private void StopWatch()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    private IEnumerator Watch()
    {
        while (true)
        {
            var a = Mathf.Abs(transform.position.x) * _Coeff;

            textBack.color = textBack.color.WithA(Mathf.Clamp(a, 0, _maxVisibility));
            text.color = text.color.WithA(Mathf.Clamp01(a));

            yield return new WaitForFixedUpdate();
        }
    }
}
