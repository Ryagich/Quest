using UnityEngine;

[RequireComponent(typeof(SizeMover))]
public class MoverToDefSize : MonoBehaviour
{
    private Vector3 defSize;

    private void Awake() =>
        defSize = transform.localScale;

    public void Move() =>
        GetComponent<SizeMover>().Move(defSize);
}
