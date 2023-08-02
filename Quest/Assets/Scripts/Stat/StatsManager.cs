using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    [SerializeField] private StatView _health;
    [SerializeField] private StatView _glory;
    [SerializeField] private StatView _sanity;
    [SerializeField] private UnlimitedStatView _unlimited1;

    private void Awake() => Instance = this;

    public void UpdateValues(int health, int glory, int sanity, int unlimited1)
    {
        _health.Model.ChangeAmount(health);
        _glory.Model.ChangeAmount(glory);
        _sanity.Model.ChangeAmount(sanity);
        _unlimited1.Model.ChangeAmount(unlimited1);
    }
}
