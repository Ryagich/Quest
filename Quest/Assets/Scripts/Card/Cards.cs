 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public List<CardData> CardData { get; private set; } = new();

    private void Awake()
    {
        var cardObjects = Resources.LoadAll("", typeof(CardData));

        foreach (var card in cardObjects)
        {
            CardData.Add(card as CardData);
        }
    }
}
