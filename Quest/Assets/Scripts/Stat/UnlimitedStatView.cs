using UnityEngine;
using System.Collections;
using TMPro;

public class UnlimitedStatView : MonoBehaviour
{
    public StatModel Model { get; private set; }

    [SerializeField] private TMP_Text _text;
    [SerializeField, Min(0)] private int _amount = 60;
    [SerializeField, Min(.0f)] private float _fillSpeed = .25f;

    private Coroutine coroutine;
    private float currectAmount;

    private void Awake()
    {
        Model = new StatModel(_amount, int.MaxValue);
        Model.AmountChanged += UpdateView;
        currectAmount = _amount;
        UpdateBar();
    }

    private void UpdateView(int currectAmount, int _)
    {
        this.currectAmount = currectAmount;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(Fill());
    }

    private IEnumerator Fill()
    {
        while (currectAmount != _amount)
        {
            if (currectAmount < _amount)
                _amount--;
            else
                _amount++;

            UpdateBar();
            yield return new WaitForSeconds(_fillSpeed);
        }
    }

    private void UpdateBar()
        => _text.text = _amount.ToString();
}