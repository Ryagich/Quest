using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData Data { get; private set; }
    [field: SerializeField] public SpriteRenderer Sprite { get; private set; }

    public void Init(CardData data)
    {
        Data = data;
        Sprite.sprite = Data.Sprite;
    }
}
