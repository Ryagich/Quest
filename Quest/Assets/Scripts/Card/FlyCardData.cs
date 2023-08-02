using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlyCardData", menuName = "FlyCardData", order = 1)]
public class FlyCardData : CardData
{
    public List<ButtonData> Buttons => _buttons;

    [Space]
    [Header("Buttons")]
    [SerializeField] private List<ButtonData> _buttons;
}
