using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAlignmentChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text _main;
    [SerializeField] private TMP_Text _add;

    private void Awake()
    {
        GetComponent<CardSpawner>().Spawn += Changer;
    }

    private void Changer(CardData data, Card card)
    {
        if (card is SimpleCard)
        {
            _main.alignment = TextAlignmentOptions.Top;
            _add.alignment = TextAlignmentOptions.Top;
        }
        else
        {
            _main.alignment = TextAlignmentOptions.TopLeft;
            _add.alignment = TextAlignmentOptions.TopLeft;

        }
    }
}
