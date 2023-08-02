using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class FlipSetterByMouseClick : MonoBehaviour
{
    private Flipper flipper;

    private void Awake()
    {
        flipper = GetComponent<Flipper>();
        InputHandler.LeftMouseDown += flipper.GetInPlace;
    }
    private void OnDestroy() =>
        InputHandler.LeftMouseDown -= flipper.GetInPlace;
}
