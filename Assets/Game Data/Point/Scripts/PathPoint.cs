using UnityEngine;

public abstract class PathPoint : Point, ISeletable
{
    public abstract void Cancel();
    public abstract void Select();
    public abstract void Add(Color color);
    public abstract void Remove();
}
