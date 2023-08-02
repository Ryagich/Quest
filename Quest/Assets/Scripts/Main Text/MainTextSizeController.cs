using UnityEngine;

public class MainTextSizeController : MonoBehaviour
{
    [SerializeField] private RectTransform _rect;

    private void Awake()
    {
        GetComponent<CardSpawner>().Spawn += UpdateSize;
    }

    private void UpdateSize(CardData _, Card card)
    {
        _rect.offsetMax = new Vector2(card is SimpleCard ? -10 : -190, _rect.offsetMax.y);
    }
}
