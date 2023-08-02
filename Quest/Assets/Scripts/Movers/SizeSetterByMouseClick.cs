using UnityEngine;

[RequireComponent(typeof(SizeMover))]
public class SizeSetterByMouseClick : MonoBehaviour
{
    private SizeMover mover;

    private void Awake()
    {
        mover = GetComponent<SizeMover>();
        InputHandler.LeftMouseDown += mover.GetInPlace;
    }

    private void OnDestroy() =>
        InputHandler.LeftMouseDown -= mover.GetInPlace;
}
