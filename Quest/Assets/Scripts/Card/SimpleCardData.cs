using UnityEngine;

[CreateAssetMenu(fileName = "SimpleCardData", menuName = "SimpleCardData", order = 1)]
public class SimpleCardData : CardData
{
    public string LeftAction => _leftAction;
    public string RightAction => _rightaction;
   
    [Header("Left")]
    [SerializeField, TextArea(1, 10)] private string _leftAction;
    [field: SerializeField] public int LeftHealth { get; private set; }
    [field: SerializeField] public int LeftGlory { get; private set; }
    [field: SerializeField] public int LeftSanity { get; private set; }
    [field: SerializeField] public int LeftUnlimited1 { get; private set; }
    
    [Space]
    [Header("Right")]
    [SerializeField, TextArea(1, 10)] private string _rightaction;
    [field: SerializeField] public int RightHealth { get; private set; }
    [field: SerializeField] public int RightGlory { get; private set; }
    [field: SerializeField] public int RightSanity { get; private set; }
    [field: SerializeField] public int RightUnlimited1 { get; private set; }

}
