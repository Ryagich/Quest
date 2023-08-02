using System;
using UnityEngine;

public class StatModel
{
    public event Action<int, int> AmountChanged;

    public int Amount { get; private set; }
    public int MaxAmount { get; private set; }

    public StatModel(int amount, int maxAmount)
    {
        Amount = amount;
        MaxAmount = maxAmount;
    }

    public void ChangeAmount(int value)
    {
        if (value == 0)
            return;

        Amount = Mathf.Clamp(Amount + value, 0, MaxAmount);
        AmountChanged?.Invoke(Amount, MaxAmount);
    }
}
