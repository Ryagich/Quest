using System;

public interface IReseter 
{
    public event Action Reseted;

    public void Reset();
}
