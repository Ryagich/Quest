using UnityEngine;

[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Mover))]
public class PlaceChangerAfterFlip : MonoBehaviour
{
    [SerializeField] private Vector3 _target;
    [SerializeField] private Mover mover;

    private void Awake() =>
        GetComponent<Flipper>().GotToPlace += () =>
        mover.Move(_target);
}
