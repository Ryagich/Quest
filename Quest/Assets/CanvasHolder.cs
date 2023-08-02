using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHolder : MonoBehaviour
{
    public static CanvasHolder Instance { get; private set; }
    public Canvas Canvas => _canvas;

    [SerializeField] private Canvas _canvas;

    private void Awake() => Instance = this;
}
