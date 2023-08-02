using System;
using UnityEngine;

public class FlyReseter : MonoBehaviour, IReseter
{
    public event Action Reseted;

    [SerializeField] private Mover mover;

    private SizeSetterByMouseClick sizer;

    private void Awake()
    {
        sizer = GetComponent<SizeSetterByMouseClick>();
        GetComponent<ButtonsCreator>().OnButtonClick += MoveBack;
    }

    private void MoveBack()
    {
        GetComponent<MoverToDefPosition>().Move();
        GetComponent<MoverToDefSize>().Move();
        mover.GotToPlace += Reset;
    }

    public void Reset()
    {
        mover.GotToPlace -= Reset;
        mover.Move(transform.position.WithY(-300));
        mover.GotToPlace += () => Destroy(gameObject);
        Reseted?.Invoke();
    }
}
