using UnityEngine;

public class SimpleFiller : MonoBehaviour
{
    private void Awake() =>
        GetComponent<IReseter>().Reseted += Fill;

    private void Fill()
    {
        var manager = StatsManager.Instance;
        var data = (SimpleCardData)GetComponent<Card>().Data;

        if (transform.position.x < 0)
            manager.UpdateValues(data.LeftHealth, data.LeftGlory,
                                 data.LeftSanity, data.LeftUnlimited1);
        else
            manager.UpdateValues(data.RightHealth, data.RightGlory,
                                 data.RightSanity, data.RightUnlimited1);
    }
}
