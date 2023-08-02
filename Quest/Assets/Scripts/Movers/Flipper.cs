using UnityEngine;

public class Flipper : Mover
{
    public override void PlaceInTarget()
    {
        transform.eulerAngles = transform.eulerAngles.WithY(target.y);
        InvokeEndEvent();
    }

    public override bool CanLoopBeCoroutine() =>
             Mathf.Abs(target.y - transform.eulerAngles.y) > _offset;

    public override void MakeIteration() =>
        transform.eulerAngles = transform.eulerAngles
                .WithY(Mathf.MoveTowards(transform.eulerAngles.y,
                 target.y, _speed * Time.fixedDeltaTime));
}
