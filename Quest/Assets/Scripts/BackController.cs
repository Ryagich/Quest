using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour
{
    public static BackController Instance;

    [SerializeField] private GameObject Back;
    private Card card;

    private void Awake()
    {
        Instance = this;

        GetComponent<CardSpawner>().Spawn += TryHide;
    }

    private void TryHide(CardData _, Card card)
    {
        if (card is not FlyCard)
            return;
        this.card = card;
        card.GetComponent<Flipper>().GotToPlace += Hide;
    }

    private void Hide()
    {
        Back.SetActive(false);
        card.GetComponent<IReseter>().Reseted += Show;
    }

    private void Show()
    {
        Back.SetActive(true);
        card.GetComponent<IReseter>().Reseted -= Show;
    }
}
