using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]

public class FollowReseter : MonoBehaviour, IReseter
{
    public event Action Reseted;

    [SerializeField, Min(.0f)] private float _treshold = 3f;
    [SerializeField] private Mover mover;

    private Vector3 defPos;
    private CursorFollower follower;

    private void Awake()
    {
        defPos = transform.position;

        follower = GetComponent<CursorFollower>();
        follower.EndFollow += Reset;
    }

    public void Reset()
    {
        if (transform.position.x < -_treshold
         || transform.position.x > _treshold)
        {
            Destroy(follower);

            var target = transform.position.WithY(-200);
            mover.Move(target);
            mover.GotToPlace += () => Destroy(gameObject);
            Reseted?.Invoke();
        }
        else
            mover.Move(defPos);
    }
}
