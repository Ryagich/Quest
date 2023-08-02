using System;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public event Action<CardData, Card> Spawn;

    [SerializeField] private Vector3 _defPlace;
    [SerializeField] private Quaternion _defRotation;
    [SerializeField] private Vector3 _targetRotation = Vector3.zero;

    private Cards cards;

    private void Start()
    {
        cards = GetComponent<Cards>();
        SpawnCard();
    }

    private void SpawnCard()
    {
        var card = GetCard();
        card.GetComponent<IReseter>().Reseted += SpawnCard;
    }

    private Card GetCard() =>
        InstantiateCard(cards.CardData[UnityEngine.Random.Range(0, cards.CardData.Count)]);

    private Card InstantiateCard(CardData data)
    {
        var cardObj = Instantiate(data.Card, _defPlace, _defRotation);
        InitCard(data, cardObj);
        return cardObj;
    }

    private void InitCard(CardData data, Card card)
    {
        card.Init(data);
        card.GetComponent<Flipper>().Move(_targetRotation);
        Spawn?.Invoke(data, card);
    }
}
