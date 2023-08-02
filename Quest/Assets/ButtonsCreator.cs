using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsCreator : MonoBehaviour
{
    public event Action OnButtonClick;

    [SerializeField] private FlyButton _buttonPref;
    [SerializeField] private Vector3 target = new(-100f, -60f, -1f);

    private Transform canvas;
    private List<FlyButton> buttons = new();
    private Card card;
    private Flipper fliper;
    private GameObject parent;

    private void Awake()
    {
        canvas = CanvasHolder.Instance.Canvas.transform;
        fliper = GetComponent<Flipper>();
        fliper.GotToPlace += CreatButtons;

        card = GetComponent<Card>();
    }

    private void CreatButtons()
    {
        fliper.GotToPlace -= CreatButtons;

        parent = new GameObject("Buttons");
        parent.transform.parent = canvas.transform;
        parent.transform.localPosition = Vector3.zero;
        parent.transform.localScale = Vector3.one;

        var data = (FlyCardData)card.Data;

        for (int i = 0; i < data.Buttons.Count; i++)
        {
            var button = Instantiate(_buttonPref, parent.transform);
            button.Init(data.Buttons[i]);
            button.GetComponent<Mover>().Move(target.WithY(target.y * i));
            button.GetComponent<SizeMover>().Move(Vector3.one);
            button.GetComponent<Button>().onClick.AddListener(ButtonsAFK);

            buttons.Add(button);
        }
        GetComponent<IReseter>().Reseted += () => Destroy(parent);
    }

    private void ButtonsAFK()
    {
        foreach (var button in buttons)
        {
            button.GetComponent<Button>().enabled = false;
            button.GetComponent<Mover>().Move(Vector3.zero);
            button.GetComponent<SizeMover>().Move(Vector3.zero);
        }

        OnButtonClick?.Invoke();
    }
}
