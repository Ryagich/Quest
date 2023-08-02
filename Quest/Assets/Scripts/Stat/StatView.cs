using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatView : MonoBehaviour
{
    public StatModel Model { get; private set; }

    [SerializeField] private Image _fillBar;
    [SerializeField, Min(0)] private int _amount = 60;
    [SerializeField, Min(0)] private int _maxAmount = 100;
    [SerializeField, Min(.0f)] private float _fillSpeed = .1f;

    private float currectRatio;
    private float currentRatio;
    private Coroutine coroutine;

    private void Awake()
    {
        Model = new StatModel(_amount, _maxAmount);
        Model.AmountChanged += UpdateView;

        currectRatio = GetRatio(_amount, _maxAmount);
        currentRatio = GetRatio(_amount, _maxAmount);

        UpdateView(_amount, _maxAmount);
        UpdateBar();
    }

    private float GetRatio(float amount, float maxAmount) =>
        amount == 0 ? 0 : amount / maxAmount;

    private void UpdateView(int amount, int maxAmount)
    {
        currectRatio = GetRatio(amount, maxAmount);

        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(Fill());
    }

    private IEnumerator Fill()
    {
        while (currectRatio != currentRatio)
        {
            currentRatio = Mathf.MoveTowards(currentRatio,
                                             currectRatio,
                                             _fillSpeed * Time.fixedDeltaTime);
            UpdateBar();
            yield return new WaitForFixedUpdate();
        }
    }

    private void UpdateBar()
        => _fillBar.fillAmount = currentRatio;
}
