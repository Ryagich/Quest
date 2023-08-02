using UnityEngine;

public class CardData : ScriptableObject
{
    public string Text => _text;
    public Sprite Sprite => _sprite;

    [Header("Main")]
    [SerializeField] private Sprite _sprite;
    [field: SerializeField] public Card Card { get; private set; }
    [SerializeField, TextArea(5, 50)] private string _text;
}