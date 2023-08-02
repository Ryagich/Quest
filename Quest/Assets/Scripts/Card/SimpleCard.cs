using System.Collections;
using UnityEngine;
using TMPro;

public class SimpleCard : Card
{
    [field: SerializeField] public TMP_Text Action { get; private set; }
    [field: SerializeField] public SpriteRenderer ActionBackground { get; private set; }
}
