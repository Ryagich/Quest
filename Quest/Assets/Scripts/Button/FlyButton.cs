using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlyButton : MonoBehaviour
{
    TMP_Text text;
    private ButtonData data;
    private Button button;

    public void Init(ButtonData data)
    {
        this.data = data;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        text = GetComponentInChildren<TMP_Text>();
        text.text = data.Text;
    }

    private void OnClick()
    {
        StatsManager.Instance.UpdateValues(data.Health, data.Glory, data.Sanity, data.Unlimited1);
        Debug.Log("Click");
    }
}
