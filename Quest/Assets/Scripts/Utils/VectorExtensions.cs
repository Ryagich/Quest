using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 WithX(this Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);
    public static Vector3 WithY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);
    public static Vector3 WithZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);

    public static Vector2 WithX2(this Vector3 vector, float x) => new Vector2(x, vector.y);
    public static Vector2 WithY2(this Vector3 vector, float y) => new Vector2(vector.x, y);
}
