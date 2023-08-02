using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static event Action<Vector3> OnMouse;
    public static event Action<float> OnMouseX;
    public static event Action<float> OnMouseY;

    public static event Action LeftMouseDown;
    public static event Action LeftMouseUp;
    public static event Action LeftMousePress;
    public static event Action RightMouseDown;
    public static event Action RightMouseUp;
    public static event Action SpacePress;
    public static event Action IDown;
    public static event Action RDown;
    public static event Action FDown;
    public static event Action ShiftDown;
    public static event Action ShiftUp;
    public static event Action LeftCtrlDown;
    public static event Action LeftCtrlUp;
    public static event Action CDown;
    public static event Action CUp;
    public static event Action ShiftPress;
    public static event Action VDown;
    public static event Action TabDown;
    public static event Action TabUp;
    public static event Action EscUp;
    public static event Action TUp;
    public static event Action TDown;

    public static Vector3 Movement;

    public static bool IsLeftMouse { get; private set; } = false;
    public static bool IsRightMouse { get; private set; } = false;
    public static bool IsShift { get; private set; } = false;
    public static bool IsLeftCtrl { get; private set; }
    public static Vector2 MousePos => Input.mousePosition;
    public static Vector3 MousePos3 => Input.mousePosition;
    public static Vector3 MouseWorldPos(float distance) =>
        Camera.main.ScreenPointToRay(MousePos3).GetPoint(distance);


    private void Update()
    {
        Movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        OnMouse?.Invoke(Input.mousePosition);
        OnMouseX?.Invoke(Input.GetAxis("Mouse X"));
        OnMouseY?.Invoke(Input.GetAxis("Mouse Y"));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsLeftMouse = true;
            LeftMouseDown?.Invoke();
        }
        if (Input.GetKey(KeyCode.Mouse0))
            LeftMousePress?.Invoke();
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsLeftMouse = false;
            LeftMouseUp?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            IsRightMouse = true;
            RightMouseDown?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            IsRightMouse = false;
            RightMouseUp?.Invoke();
        }

        if (Input.GetKey(KeyCode.Space))
            SpacePress?.Invoke();
        if (Input.GetKeyDown(KeyCode.I))
            IDown?.Invoke();
        if (Input.GetKeyDown(KeyCode.R))
            RDown?.Invoke();
        if (Input.GetKeyDown(KeyCode.F))
            FDown?.Invoke();

        if (Input.GetKeyDown(KeyCode.T))
            TDown?.Invoke();
        if (Input.GetKeyUp(KeyCode.T))
            TUp?.Invoke();

        if (Input.GetKey(KeyCode.LeftShift))
            ShiftPress?.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IsShift = true;
            ShiftDown?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsShift = false;
            ShiftUp?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IsLeftCtrl = true;
            LeftCtrlDown?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsRightMouse = false;
            LeftCtrlUp?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.C))
            CDown?.Invoke();

        if (Input.GetKeyUp(KeyCode.C))
            CUp?.Invoke();

        if (Input.GetKeyDown(KeyCode.V))
            VDown?.Invoke();

        if (Input.GetKeyDown(KeyCode.Tab))
            TabDown?.Invoke();

        if (Input.GetKeyUp(KeyCode.Tab))
            TabUp?.Invoke();

        if (Input.GetKeyUp(KeyCode.Escape))
            EscUp?.Invoke();
    }
}
