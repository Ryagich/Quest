using UnityEngine;

[RequireComponent(typeof(Mover))]
public class MoverToDefPosition : MonoBehaviour
{
    [SerializeField] private Mover mover;

    private Vector3 defPos;

    private void Awake() =>
        defPos = transform.position;

    public void Move() =>
        mover.Move(defPos);
}
