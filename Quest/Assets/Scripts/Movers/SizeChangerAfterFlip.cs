using UnityEngine;

[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(SizeMover))]
public class SizeChangerAfterFlip : MonoBehaviour
{
    [SerializeField] private Vector3 _target = new(40f, 40f, 1f);

    private void Awake()
       => GetComponent<Flipper>().GotToPlace += ()
       => GetComponent<SizeMover>().Move(_target);
}
