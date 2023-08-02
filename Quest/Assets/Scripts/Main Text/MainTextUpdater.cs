using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class MainTextUpdater : MonoBehaviour
{
    public event Action StarWrite;
    public event Action EndWrite;
    public bool IsWrite => coroutine != null;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _addText;
    [SerializeField, Min(.0f)] private float _WriteSpeed = .5f;

    private Coroutine coroutine;
    private string target = "";
    private string str = "";

    private void Awake()
    {
        GetComponent<CardSpawner>().Spawn += UpdateText;
        InputHandler.LeftMouseDown += TryShowText;
    }

    private void UpdateText(CardData data, Card _)
    {
        _text.text = "";
        _addText.text = "";
        str = "";

        target = data.Text;
        coroutine = StartCoroutine(Write());
    }

    private void TryShowText()
    {
        if (!IsWrite)
            return;
        ShowText();
    }

    private void ShowText()
    {
        StopCoroutine(coroutine);

        var currText = _text;
        while (str != target)
        {
            while (target[str.Length] == ' ')
            {
                currText.text += target[str.Length];
                str += target[str.Length];
            }
            currText.text += target[str.Length];
            str += target[str.Length];

            if (currText.preferredHeight > currText.rectTransform.rect.height)
            {
                int i;
                for (i = str.Length - 1; i > 0; i--)
                    if (str[i] == ' ')
                        break;
                str = str.Remove(i);
                currText.text = str;
                currText = _addText;
            }
        }
        EndWrite?.Invoke();
    }

    private IEnumerator Write()
    {
        var currText = _text;

        StarWrite?.Invoke();
        while (str != target)
        {
            currText = WriteChar(currText);

            yield return new WaitForSeconds(_WriteSpeed);
        }
        EndWrite?.Invoke();
    }

    private TMP_Text WriteChar(TMP_Text currText)
    {
        while (target[str.Length] == ' ')
        {
            currText.text += target[str.Length];
            str += target[str.Length];
        }
        currText.text += target[str.Length];
        str += target[str.Length];

        if (currText.preferredHeight > currText.rectTransform.rect.height)
        {
            int i;
            for (i = str.Length - 1; i > 0; i--)
                if (str[i] == ' ')
                    break;
            str = str.Remove(i);
            currText.text = str;
            currText = _addText;
        }

        return currText;
    }
}

