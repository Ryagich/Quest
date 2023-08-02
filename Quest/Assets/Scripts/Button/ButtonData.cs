using System;
using UnityEngine;

[Serializable]
public class ButtonData
{
    public string Text => _text;
    public int Health => _health;

    [Header("Main")]
    [SerializeField, TextArea(5, 50)] private string _text;

    [Space]
    [Header("Stats")]
    [SerializeField] private int _health;
    [field: SerializeField] public int Glory { get; private set; }
    [field: SerializeField] public int Sanity { get; private set; }
    [field: SerializeField] public int Unlimited1 { get; private set; }
}
