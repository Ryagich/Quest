using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PlaceSetterByMouseClick : MonoBehaviour
{
    [SerializeField] private Mover mover;

    private void Awake() =>
        InputHandler.LeftMouseDown += mover.GetInPlace;

    private void OnDestroy() =>
        InputHandler.LeftMouseDown -= mover.GetInPlace;
}
