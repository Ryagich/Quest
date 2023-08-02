using System.Collections;
using TMPro;
using UnityEngine;

public class ActionDialogue : MonoBehaviour
{
    [SerializeField] private Mover mover;

    private TMP_Text text;
    private Coroutine coroutine;
    private SimpleCard card;

    private void Awake()
    {
        card = GetComponent<SimpleCard>();
        text = card.Action;

        mover.GotToPlace += StopShow;
        GetComponent<CursorFollower>().StartFollow += () =>
                    coroutine = StartCoroutine(Show());
        GetComponent<FollowReseter>().Reseted += StopShow;
    }

    private void StopShow()
    {
        if (coroutine == null)
            return;
        StopCoroutine(coroutine);
    }

    private IEnumerator Show()
    {
        var data = (SimpleCardData)card.Data;
        while (true)
        {
            if(transform.position.x > 0)
            {
                text.alignment = TextAlignmentOptions.MidlineRight;
                text.text = data.RightAction;
            }
            else
            {
                text.alignment = TextAlignmentOptions.MidlineLeft;
                text.text = data.LeftAction;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}